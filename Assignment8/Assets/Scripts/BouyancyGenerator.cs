using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BouyancyGenerator : ForceGenerator2D
{
    
    float mSurfaceHeight = 5;
    float mMaxDepth = 0.25f;
    float mVolume = 1;
    float mLiquidDensity = .1f;

    void Start()
    {
       
    }

    public override void UpdateForce(GameObject particle)
    {
        
        if(!particle)
        {
            Debug.Log("testing");
        }

        float depth = particle.transform.position.y;

       
        if (depth >= mSurfaceHeight + mMaxDepth)
        {
           
            return;
        }
       
        Vector2 force = new Vector2(0,0);

        if (depth <= mSurfaceHeight - mMaxDepth)
        {
            force.y = mLiquidDensity * mVolume;
            particle.GetComponent<Particle2D>().AddForce(-force);
            
            return;
        }
        float d = ((depth - mMaxDepth - mSurfaceHeight) / (2 * mMaxDepth));
        force.y = mLiquidDensity * mVolume * d;

      
        particle.GetComponent<Particle2D>().AddForce(force);
    }

    public override void SetID(int id)
    {
        mId = id;

    }

}
