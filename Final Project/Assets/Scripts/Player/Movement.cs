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

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        P2D.Acceleration = new Vector2(baseAcc.x + (h * speed), baseAcc.y + (v * jump));

    }

}

