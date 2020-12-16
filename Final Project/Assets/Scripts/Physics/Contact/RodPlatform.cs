using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject particleLinkObject = new GameObject("LINK " + GameObject.Find("RodAnchor").name + " " + GameObject.Find("RodPlatform").name);
        ParticleRod newParticleRod = particleLinkObject.AddComponent<ParticleRod>();
        newParticleRod.Initialize(GameObject.Find("RodPlatform"), GameObject.Find("RodAnchor"), 10);
        ContactResolver.Instance.mParticleLinks.Add(newParticleRod);
        
        //Swing Platform
        GameObject particleLinkObject2 = new GameObject("LINK " + GameObject.Find("SwingAnchor").name + " " + GameObject.Find("SwingPlatform").name);
        ParticleRod particleRod = particleLinkObject.AddComponent<ParticleRod>();
        particleRod.Initialize(GameObject.Find("SwingPlatform"), GameObject.Find("SwingAnchor"), 10);
        ContactResolver.Instance.mParticleLinks.Add(particleRod);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
