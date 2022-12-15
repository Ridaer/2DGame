using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjMovement : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    private float move;
    private float speed;
    public float acceleration = 4f;
    public float decceleration = 6f;
    public float maxSpeed = 8f;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(speed, Rigidbody2D.velocity.y);
    }

    private void Move()
    {
        move = Input.GetAxisRaw("Horizontal");
        HorizontalAcceleration();
    }

    private void HorizontalAcceleration()
    {
        if(move == 0)
        {
            if (Mathf.Abs(speed) <= 0.1f)
            {
                speed = 0;
            }
            else
            {
                if(speed >0)
                {
                    speed -= decceleration * Time.deltaTime;
                }
                else
                {
                    speed += decceleration * Time.deltaTime;    
                }
            }
        }
        else
        {
            if(move * speed <0)
            {
                speed += decceleration + Time.deltaTime * move;
            }
            else
            {
                if (Mathf.Abs(speed) >= maxSpeed)
                {
                    speed =  maxSpeed * move;
                }
                else
                {
                    speed += acceleration + Time.deltaTime * move;
                }

            }
        }
    }
}
