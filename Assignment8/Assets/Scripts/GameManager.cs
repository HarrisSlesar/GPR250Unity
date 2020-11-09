using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public static List<GameObject> particleList = new List<GameObject>();
    static int unitID = 0;
    BouyancyGenerator generator = new BouyancyGenerator();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        instance = this;
        
        
        generator = GetComponent<BouyancyGenerator>();
        generator.SetShouldEffectAll(true);
        ForceManager.AddGenerator(generator);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       for(int i = 0; i < particleList.Count; i++)
       {
           Integrator.Integrate(particleList[i]);
       }
    }

    public List<GameObject> getList()
    {
        return particleList;
    }

    public static void addParticle(GameObject particle)
    {
        particleList.Add(particle);
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



        projectile.GetComponent<Particle2D>().Create(1, forward, new Vector2(0, -.01f), 0.999f, 3, unitID);
        particleList.Add(projectile);
        unitID += 1;
        if (type.name.Contains("Spring"))
        {
            GameObject projectile2 = Instantiate(type, trans.position, trans.rotation);
            projectile2.GetComponent<Particle2D>().Create(1, forward, new Vector2(0, -.01f), 0.999f, 1, unitID);
            particleList.Add(projectile2);
            unitID += 1;
            SpringGenerator newGenerator = new SpringGenerator();
            newGenerator.SetShouldEffectAll(false);
            ForceManager.AddGenerator(newGenerator);
            newGenerator.SetID(projectile.GetComponent<Particle2D>().GetID(), projectile2.GetComponent<Particle2D>().GetID());

        }
        
    }
    

}

