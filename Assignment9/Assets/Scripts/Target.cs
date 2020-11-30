using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit()
    {
        Debug.Log("collide");
        GameManager.score += 1;
        Vector2 newPos = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        gameObject.transform.position = newPos;
    }

    
}
