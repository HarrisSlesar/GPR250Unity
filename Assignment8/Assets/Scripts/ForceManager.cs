using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceManager : MonoBehaviour
{

    public static List<ForceGenerator2D> generatorList = new List<ForceGenerator2D>();
    public static ForceManager instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateForces();
       
    }

    public static void AddGenerator(ForceGenerator2D gen)
    {
        generatorList.Add(gen);
        Debug.Log("Gen added");
        Debug.Log(generatorList.Count);
    }

    public static void UpdateForces()
    {
       
        GameObject particle;
       

        foreach (ForceGenerator2D var in generatorList)
        {

            if (var.GetShouldEffectAll() == true)
            {
                foreach (GameObject par in GameManager.particleList)
                {
                    if(par != null)
                        var.UpdateForce(par);
                }
            }
            else
            {
                particle = GameManager.particleList[var.GetID()];
                if (particle != null)
                {
                    if (particle.GetComponent<Particle2D>().GetID() == var.GetID())
                    {
                        var.UpdateForce(particle);
                    }
                }
            }
        }
           
           
    }
}

    

    

