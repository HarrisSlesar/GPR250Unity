using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public static CollisionDetector instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool DetectCollision(GameObject par1, GameObject par2)
    {
        
        if (Vector2.Distance(par1.transform.position, par2.transform.position) <= par1.transform.lossyScale.x/2)
        {
            return true;
        }
        else
            return false;
    }
}
