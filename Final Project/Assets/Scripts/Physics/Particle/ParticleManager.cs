using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static ParticleManager instance;

    public static ParticleManager Instance { get { return instance; } }

    public List<Particle2D> mParticles = new List<Particle2D>();
    List<Particle2D> mParticlesToDelete = new List<Particle2D>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Particle2D[] particles = (Particle2D[])GameObject.FindObjectsOfType(typeof(Particle2D));
        foreach (Particle2D particle in particles)
        {
            mParticles.Add(particle);
        }
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Particle2D particle in mParticles)
        {
            foreach (Particle2D particle2 in mParticles)
            {
                 if (particle != particle2)
                 {
                    if (CollisionDetector.DetectRecCollision(particle, particle2))
                    {
                        if (particle.isPlayer)
                        {
                            if (!particle.isGrounded)
                            {
                                particle.isGrounded = true;
                                particle.transform.position = new Vector2(particle.transform.position.x, particle2.transform.position.y + particle2.height + particle.height);
                                
                                particle.Velocity = particle2.Velocity;
                                particle.Acceleration = particle2.Velocity;
                                /*
                                Vector2 cOfMass = (particle.Velocity + particle2.Velocity) / 2;
                                Vector2 normal1 = particle2.transform.position - particle.transform.position;
                                normal1.Normalize();
                                Vector2 normal2 = particle.transform.position - particle2.transform.position;
                                normal2.Normalize();

                                particle.Velocity -= cOfMass;
                                particle.Velocity = Vector2.Reflect(particle.Velocity, normal1);
                                particle.Velocity += cOfMass;

                                particle2.Velocity -= cOfMass;
                                particle2.Velocity = Vector2.Reflect(particle2.Velocity, normal2);
                                particle2.Velocity += cOfMass;
                                */
                            }

                        }
                    }
                    else
                    {
                        particle.isGrounded = false;
                    }
                 }
                
            }
        }
        foreach (Particle2D particle in mParticlesToDelete)
        {
            DeleteParticle(particle);
        }
        mParticlesToDelete.Clear();
    }
    public void DeleteParticle(Particle2D particle)
    {
        mParticles.Remove(particle);
        Destroy(particle.gameObject);
    }
}
