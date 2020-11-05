using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    List<GameObject> particleList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public List<GameObject> getList()
    {
        return particleList;
    }

    public void addParticle(GameObject particle)
    {
        particleList.Add(particle);
    }


    
    

}

