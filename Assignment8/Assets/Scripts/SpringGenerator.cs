using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringGenerator : ForceGenerator2D
{

    int ID2;
    float springConstant = 2f;
    float restLength = .3f;

    void Start()
    {

    }

    public override void UpdateForce(GameObject particle)
    {
        particle = GameManager.particleList[mId];
        GameObject particle2 = GameManager.particleList[ID2];
        if (!particle || !particle2)
        {
            Debug.Log("no particles");
        }

        Vector2 pos1 = particle.transform.position;
        Vector2 pos2 = particle2.transform.position;

        Vector2 diff = pos1 - pos2;

        float dist = diff.magnitude;

        float magnitude = dist - restLength;
        Debug.Log(magnitude);
        //if (magnitude < 0.0f)
        //magnitude = -magnitude;
        magnitude *= springConstant;
       

        diff.Normalize();
        diff *= -magnitude;
       

        particle2.GetComponent<Particle2D>().AddForce(diff);
        particle.GetComponent<Particle2D>().AddForce(new Vector2(-diff.x, -diff.y));

    }

    public void SetID(int id, int id2)
    {
        mId = id;
        ID2 = id2;
    }


    

        
}
