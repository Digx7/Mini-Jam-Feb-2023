using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    bool moving;
    public float runSpeed = 0.01f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        moving = gameObject.GetComponent<Animator>().GetBool("moving");
    }

    void Update()
    {
        checkInput();
        checkMoving();
        checkFlip();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed * 0.01f, vertical * runSpeed * 0.01f);
    }
    
    private void checkInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    
    private void checkMoving()
    {
        if (body.velocity.x != 0f || body.velocity.y != 0f)
        {
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            print("hi");
        }
        if (body.velocity.x == 0f && body.velocity.y == 0f)
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }
    }

    private void checkFlip() 
    {
        if(body.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (body.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
