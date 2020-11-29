using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2D : MonoBehaviour
{
    int unitID;
    public int contactId;
    float mass;
    Vector2 velocity;
    float speed;
    Vector2 direction;
    Vector2 acceleration;
    Vector2 accumulatedForces;
    float dampingConstant;
    public bool shouldIgnoreForces;
    public bool shouldBeDestroyed = false;

    ForceGenerator2D generator = new ForceGenerator2D();

    // Start is called before the first frame update
    void Start()
    {
       
        shouldIgnoreForces = false;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.gameObject.GetComponent<Renderer>().isVisible)
        {

            shouldBeDestroyed = true;
            GameManager.destroyList.Add(unitID);

        }
        //Debug.Log(velocity);
        
    }

    public void Create(float m, Vector2 dir, Vector2 a, float d, float s, int id)
    {
        mass = m;
        direction = dir;
        acceleration = a;
        dampingConstant = d;
        speed = s;
        velocity = direction * speed;
        // Debug.Log(direction);
        unitID = id;
       
        //generator = new BouyancyGenerator();
        //generator.SetID(id);
        //ForceManager.AddGenerator(generator);


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
        return 1.0f/mass;
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

    

    public void AddForce(Vector2 force)
    {
        accumulatedForces += force;
    }

    public int GetID()
    {
        return unitID;
    }

    
}
