using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static List<GameObject> particleList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
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

        Vector3 facing = trans.rotation * Vector3.forward;
        projectile.GetComponent<Particle2D>().Create(1, new Vector2(1, 0), new Vector2(0, -0.01f), 0.999f);
        particleList.Add(projectile);
    }
    

}

