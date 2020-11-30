using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private List<GameObject> particleList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetParticle(int id)
    {
        return particleList[id];
    }

    public void AddParticle(GameObject particle)
    {
        particleList.Add(particle);
    }

    public void ParticleUpdate()
    {
        foreach(GameObject par1 in particleList)
        {
            foreach(GameObject par2 in particleList)
            {
                if(par1 != par2 && par1 != null && par2 != null)
                {
                    bool colliding = CollisionDetector.DetectCollision(par1, par2);
                    if (colliding == true)
                    {
                        if (!GameManager.destroyList.Contains(par1.GetComponent<Particle2D>().GetID()))
                        {
                            GameManager.destroyList.Add(par1.GetComponent<Particle2D>().GetID());
                        }
                        if (!GameManager.destroyList.Contains(par2.GetComponent<Particle2D>().GetID()))
                        {
                            GameManager.destroyList.Add(par2.GetComponent<Particle2D>().GetID());
                        }
                    }
                }
            }
           
        }
        foreach (GameObject par in particleList)
        {
            if (par != null)
            {
                Vector3 viewPos = UnityEngine.Camera.main.WorldToViewportPoint(par.transform.position);
                if (!(viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0))
                {
                    if (!GameManager.destroyList.Contains(par.GetComponent<Particle2D>().GetID()))
                    {
                        GameManager.destroyList.Add(par.GetComponent<Particle2D>().GetID());
                    }
                }
            }
        }

    }

    public void RemoveParticle(int id)
    {
        Destroy(particleList[id]);
        particleList[id] = null;
    }

    public int GetCount()
    {
        return particleList.Count;
    }
}
