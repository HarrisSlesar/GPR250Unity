using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2D : MonoBehaviour
{
    public double Mass;
    public Vector2 Velocity;
    public Vector2 Acceleration;
    public Vector2 AccumulatedForces;
    public double DampingConstant;
    public bool shouldIgnoreForces;

    public float mRadius = 0;

    public float mLeftEdge, mRightEdge, mTopEdge, mBottomEdge;

    public float width, height;
    public float x, y;

    public bool isPlayer = false;
    public bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        width = transform.localScale.x;
        height = transform.localScale.y;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            //mRadius = spriteRenderer.bounds.extents.x;
            x = transform.position.x;
            y = transform.position.y;
            mLeftEdge = x - width / 2;
            mRightEdge = x + width / 2;
            mBottomEdge = y - height / 2;
            mTopEdge = y + height / 2;
            
        }

        if(gameObject.name.Contains("Player"))
        {
            isPlayer = true;
        }
        //else mRadius = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        mLeftEdge = x - width / 2;
        mRightEdge = x + width / 2;
        mBottomEdge = y - height / 2;
        mTopEdge = y + height / 2;

        if(!isGrounded)
        {
            Acceleration = new Vector2(Acceleration.x, -10);
        }
    }
    void OnBecameInvisible()
    {
        ParticleManager.Instance.DeleteParticle(this);
    }
}
