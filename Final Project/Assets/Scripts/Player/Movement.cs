using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    
    public float speed;
    public float jump;
    Particle2D P2D;
    Vector2 baseAcc = new Vector2(0, -10);
    void Start()
    {
        P2D = GetComponent<Particle2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");




        //gameObject.transform.position = new Vector2(transform.position.x + (float)(.01 * h), transform.position.y + (float)(.01 * v));
        //gameObject.transform.position = new Vector2(transform.position.x + (float)(.01 * h), transform.position.y + (float)(.01 * v));
        P2D.Acceleration += new Vector2(baseAcc.x + (h * speed), baseAcc.y + (v * jump));

    }

}

