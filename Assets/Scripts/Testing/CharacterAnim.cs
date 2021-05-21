using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnim : MonoBehaviour
{
    private Animator anim;

   // public float speed;  // might need to be deleted
   // public bool isGrounded; //might need to delete
    public float moveInput;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");  //---- might need to delete


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("jump");
        }
        //-------------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
       //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))      //------ Doesn't work for some reason
            {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
 
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("jumpFlip", true);
        }
        else
        {
            anim.SetBool("jumpFlip", false);
        }





        //if (GetButton("KeyOne") && GetButton("KeyTwo") {
        //    doJump = true;
        //}
        //if (doJump)
        //{
        //    //Do Jump, addforce etc...
        //    //Then turn bool off
        //    doJump = false;
        //}
    }
}