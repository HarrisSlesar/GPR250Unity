using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2D : MonoBehaviour
{
    float mass;
    Vector2 velocity;
    Vector2 acceleration;
    Vector2 accumulatedForces;
    float dampingConstant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create(float m, Vector2 v, Vector2 a, float d)
    {
        mass = m;
        velocity = v;
        acceleration = a;
        dampingConstant = d;
    }


}
