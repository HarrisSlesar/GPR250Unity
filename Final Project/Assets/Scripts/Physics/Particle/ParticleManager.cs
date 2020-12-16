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



                                if (particle.y > particle2.y + particle2.height)
                                {
                                    particle.transform.position = new Vector2(particle.transform.position.x, particle2.transform.position.y + particle2.height + particle.height+.01f);
                                    if (particle2.canMove)
                                        particle2.Velocity.y -= (float)particle.Mass / 4;

                                }
                                else if(particle.y + particle.height < particle2.y - particle2.height)
                                {
                                    particle.transform.position = new Vector2(particle.transform.position.x, particle2.transform.position.y - particle2.height - particle.height - .01f);
                                }
                                
                                if(particle.x  > particle2.x + particle2.width)
                                {
                                    particle.transform.position = new Vector2(particle2.transform.position.x + particle2.width + particle.width + .01f, particle.transform.position.y);
                                }
                                else if (particle.x < particle2.x - particle2.width)
                                {
                                    particle.transform.position = new Vector2(particle2.transform.position.x - particle2.width - particle.width - .01f, particle.transform.position.y);
                                }



                                particle.Velocity.y = particle2.Velocity.y;
                                particle.Acceleration.y = particle2.Velocity.y;


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
