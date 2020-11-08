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
        Vector3 direction = Vector3.right;
        float angle = trans.eulerAngles.z * Mathf.Deg2Rad;
        float sin = Mathf.Sin(angle);
        float cos = Mathf.Cos(angle);

        Vector3 forward = new Vector3(
            direction.x * cos - direction.y * sin,
            direction.x * sin + direction.y * cos,
            0f);



        projectile.GetComponent<Particle2D>().Create(1, forward, new Vector2(0, -0.01f), 0.999f, 2);
        particleList.Add(projectile);
    }
    

}

