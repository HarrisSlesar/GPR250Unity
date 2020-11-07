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
    public bool shouldIgnoreForces;

    // Start is called before the first frame update
    void Start()
    {
        shouldIgnoreForces = false;
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

    public Vector2 GetVelocity()
    {
        return velocity;
    }
    public Vector2 GetAcceleration()
    {
        return acceleration;
    }

    public Vector2 GetAccumulatedForces()
    {
        return accumulatedForces;
    }

    public float GetMass()
    {
        return mass;
    }

    public float GetInverseMass()
    {
        return mass * -1;
    }

    public float GetDamping()
    {
        return dampingConstant;
    }

    public void SetVel(Vector2 vel)
    {
        velocity = vel;
        return;
    }
    public void SetAcc(Vector2 acc)
    {
        acceleration = acc;
        return;
    }

    public void ClearForces()
    {
        accumulatedForces = new Vector2(0, 0);
    }
}
