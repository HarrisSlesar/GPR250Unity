using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionDetector
{
    public static bool DetectCollision(Particle2D particle, Particle2D otherParticle)
    {
        if (Vector2.Distance(particle.transform.position, otherParticle.transform.position) < particle.mRadius + otherParticle.mRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool DetectRecCollision(Particle2D particle, Particle2D particle2)
    {
        if (particle.x - particle.width < particle2.x + (particle2.width) &&
   particle.x + particle.width > particle2.x - (particle2.width) &&
   particle.y - particle.height < particle2.y + particle2.height &&
   particle.y + particle.height > particle2.y - (particle2.height))
        {
            
            return true;
            
        }
        else
            return false;
    }
}
