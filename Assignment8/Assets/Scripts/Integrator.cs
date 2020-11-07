using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Integrator : MonoBehaviour
{

    public static Integrator integratorInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void Integrate(GameObject particle)
    {
        Particle2D stats = particle.GetComponent<Particle2D>();
        Vector2 vel = stats.GetVelocity();
        
        //pData->pos += (pData->vel * (float)dt);

        particle.transform.position += new Vector3(vel.x * .016f, vel.y * .016f, 0);

        Vector2 acc = stats.GetAcceleration();

        //Vector2D resultingAcc(pData->acc);

        if (!stats.shouldIgnoreForces)//accumulate forces here
        {
            acc += stats.GetAccumulatedForces() * stats.GetInverseMass();
        }

        vel += (acc * .016f);
        double damping = Math.Pow((double)stats.GetDamping(), .016);
        vel = vel * (float)damping;

       
        stats.SetVel(vel);
        stats.SetAcc(acc);

        stats.ClearForces();
        return;
    }
    
}
