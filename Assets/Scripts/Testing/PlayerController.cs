using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;

    private Animator anim;              //Not fully needed
    //SpriteRenderer Player;     //added

    private Rigidbody2D rb;

    private bool facingRight = true;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    //bool coroutineRunning = false;     ---------------------------- movement control

    public int health;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        //health = GameObject.GetComponent<Health>();
        anim = GetComponent<Animator>();   //----added with private Animator anim;
    }

    void FixedUpdate()
    {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);  //----------- Main movement control

        if (isGrounded)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }


        

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
        {

        //---------------------------------------------------------------------------------------------------------------- other movement control #2
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //float moveInput = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.x);

        //if (moveInput < 0)
        //{
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //} else if (moveInput > 0)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //}

        //------------------------------------------------------------------------------------------------------------------




        //------------------------------------------------------------------- Main movement control

        //---------------------------------------------------------------------Extra Jumps

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)    
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)    
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //--------------------------------------------------------------------Extra Jumps end


        //------------------------------------------------------------------ Main Movement control end


        //------------------------------------------------------------------------------------------------------------------------ Other movement control end




        if (health <= 0)
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);        //death animation needs to be added
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }






    //public void GravityChange()
    //{
    //    if (!coroutineRunning)
    //    {
    //        StartCoroutine(Float());
    //    }
    //    else
    //    {
    //        StopCoroutine(Float());
    //        StartCoroutine(Float());
    //    }


    //}

    //IEnumerator Float()
    //{
    //    coroutineRunning = true;
    //    Gravity = -1;
    //    yield return new WaitForSeconds(10.0f);
    //}





}