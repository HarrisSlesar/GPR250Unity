using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    
    public static List<int> destroyList = new List<int>();
    public static int score = 0;
    public GameObject target;
    static int unitID = 0;
    BouyancyGenerator generator;
    static List<Particle2DLink> linkList = new List<Particle2DLink>();
    public static List<GameObject> contacts = new List<GameObject>();

    public static ParticleManager particleManager;
    ContactResolver resolver;
    public GameObject randomParticle;

    public GameObject contactPrefab;
    float frame = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        instance = this;

        particleManager = this.gameObject.AddComponent<ParticleManager>();
        generator = GetComponent<BouyancyGenerator>();
        generator.SetShouldEffectAll(true);
        ForceManager.AddGenerator(generator);
        resolver = this.gameObject.AddComponent<ContactResolver>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Particle2DLink it in linkList)
        {
            it.CreateContacts(particleManager.GetParticle(it.id1), particleManager.GetParticle(it.id2), contactPrefab);
        }
        
       
        resolver.resolveContacts(contacts);
        particleManager.ParticleUpdate();
        for (int i = 0; i < particleManager.GetCount(); i++)
        {
            if (particleManager.GetParticle(i) != null)
            { 
                if( Vector2.Distance(particleManager.GetParticle(i).transform.position, target.transform.position) <= .5)
                {
                    particleManager.GetParticle(i).GetComponent<Particle2D>().Remove();
                    target.GetComponent<Target>().GetHit();
                }
                Integrator.Integrate(particleManager.GetParticle(i));
            }
        }
        foreach (int itr in destroyList)
        {
            particleManager.RemoveParticle(itr);  
        }
        destroyList.Clear();
        frame += .016f;
        if(frame >= .25)
        {
            MakeRandomProjectile(randomParticle);
            frame = 0;
        }
        
    }

    public void MakeRandomProjectile(GameObject part)
    {
        Vector2 newPos = Camera.main.ViewportToWorldPoint(new Vector2(UnityEngine.Random.value, UnityEngine.Random.value));
        GameObject projectile = Instantiate(part, newPos, new Quaternion(0,0,0,0));
        projectile.GetComponent<Particle2D>().Create(1, newPos, new Vector2(0, -.01f), 0.999f, 1, unitID);
        particleManager.AddParticle(projectile);
        unitID += 1;
    }




    public static void MakeProjectile(Transform trans, GameObject type)
    {
        GameObject projectile = Instantiate(type, trans.position, trans.rotation);
        Vector3 direction = Vector3.right;
        float angle = trans.eulerAngles.z * Mathf.Deg2Rad;
        float sin = Mathf.Sin(angle);
        float cos = Mathf.Cos(angle);

        Vector3 forward = new Vector3(
            direction.x * cos - direction.y * sin,
            direction.x * sin + direction.y * cos,
            0f);



        projectile.GetComponent<Particle2D>().Create(1, forward, new Vector2(0, -.01f), 0.999f, 10, unitID);
        particleManager.AddParticle(projectile);
        unitID += 1;
        if (type.name.Contains("Spring"))
        {
            GameObject projectile2 = Instantiate(type, trans.position + new Vector3(0, .5f, 0), trans.rotation);
            projectile2.GetComponent<Particle2D>().Create(1, forward, new Vector2(0, -.01f), 0.999f, 1, unitID);
            particleManager.AddParticle(projectile2);
            unitID += 1;
            SpringGenerator newGenerator = instance.gameObject.AddComponent<SpringGenerator>();
            newGenerator.SetShouldEffectAll(false);
            ForceManager.AddGenerator(newGenerator);
            newGenerator.SetID(projectile.GetComponent<Particle2D>().GetID(), projectile2.GetComponent<Particle2D>().GetID());

        }
        else if(type.name.Contains("Rod"))
        {
            GameObject projectile2 = Instantiate(type, trans.position + new Vector3(0, .5f,0), trans.rotation);
            projectile2.GetComponent<Particle2D>().Create(1, forward, new Vector2(0, -.01f), 0.999f, 2, unitID);
            particleManager.AddParticle(projectile2);
            unitID += 1;
            Particle2DLink newLink = instance.gameObject.AddComponent<Particle2DLink>();
            newLink.id1 = projectile.GetComponent<Particle2D>().GetID();
            newLink.id2 = projectile2.GetComponent<Particle2D>().GetID();

            linkList.Add(newLink);

           
        }
        
    }
    

}

