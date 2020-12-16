using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    
    public float speed;
    public float jump;
    public bool hasJumped = false;
    public int jumpNum = 1;
    Particle2D P2D;
    void Start()
    {
        P2D = GetComponent<Particle2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        P2D.Velocity = new Vector2(h * speed, P2D.Velocity.y);
        //new Vector2(baseAcc.x + (h * speed), baseAcc.y + (v * jump));
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && jumpNum > 0)   //makes player jump
        {
            P2D.Velocity = new Vector2(P2D.Velocity.x, jump);
            jumpNum--;
            hasJumped = true;
        }
    }

}

