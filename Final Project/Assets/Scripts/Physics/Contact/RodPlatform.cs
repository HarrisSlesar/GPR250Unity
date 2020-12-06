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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
