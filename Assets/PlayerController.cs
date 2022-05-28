using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;

    //public float moveSpeed = 5;


    private float speed;
    private float boostTimer;
    private bool boosting;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = 5;
        boostTimer = 0;
        boosting = false;
    }

    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(0, moveDirection * speed);


        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 3)
            {
                speed = 5;
                boostTimer = 0;
                boosting = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedBoost")
        {
            boosting = true;
            speed = 10;
            Destroy(other.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}   
    
