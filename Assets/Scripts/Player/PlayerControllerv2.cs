using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerControllerv2 : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;
	float dirX, moveSpeed = 5f;
	public int health = 3;
	bool isHurting, isDead;
	bool facingRight = true;
	Vector3 localScale;

	public int bounceForce;

	//------------------------------------------- v1 Code variables
	private int extraJumps;
	public int score;
	public int extraJumpsValue;
	public bool isGrounded;
	public int collectible;
	//public Transform groundCheck;
	//public float checkRadius;
	//public LayerMask whatIsGround;
	//public float jumpForce;
	//-------------------------------------------

	// Use this for initialization
	//[RequireComponent(typeof(AudioSource))]
	public AudioClip jumpSFX;
	public AudioMixerGroup audioMixer;
	AudioSource jumpAudioSource;
	AudioSource pinkUpAudioSource;
	AudioSource squishAudioSource;
	public AudioClip squishSFX;
	AudioSource pickupAudioSource;
	public AudioClip pickUpSFX;
	





	void Start()
	{
		

		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		localScale = transform.localScale;
		extraJumps = extraJumpsValue;              //v1 Code 
		//pickupAudioSource = GetComponent<AudioSource>();


		if (bounceForce <= 0)
		{
			bounceForce = 50;
		}
	}

	void Update()
	{
		if (Time.timeScale != 0)
		{
			if (Input.GetButtonDown("Jump") && !isDead && rb.velocity.y == 0)
			{
				rb.AddForce(Vector2.up * 200f);
				if (!jumpAudioSource)
				{
					jumpAudioSource = gameObject.AddComponent<AudioSource>();
					jumpAudioSource.clip = jumpSFX;
					jumpAudioSource.outputAudioMixerGroup = audioMixer;
					jumpAudioSource.loop = false;
				}
				
				jumpAudioSource.Play();
			}

			

			if (Input.GetKey(KeyCode.Space))
				moveSpeed = 8f;
			else
				moveSpeed = 5f;

			SetAnimationState();

			

		if (!isDead)
				dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

			if (isGrounded == true)
			{
				extraJumps = extraJumpsValue;
			}

			if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
			{
				rb.AddForce(Vector2.up * 200f);     //rb.velocity = Vector2.up * jumpForce;
				extraJumps--;
			}
			else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
			{
				rb.AddForce(Vector2.up * 100f); //rb.velocity = Vector2.up * jumpForce;
			}
		}
	}


	void FixedUpdate()
	{
		if (!isHurting)
			rb.velocity = new Vector2(dirX, rb.velocity.y);
		//isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
	}

	void LateUpdate()
	{
		CheckWhereToFace();
	}

	void SetAnimationState()
	{

		if (dirX == 0)
		{
			anim.SetBool("isWalking", false);
			anim.SetBool("isRunning", false);
			anim.SetBool("isGrounded", true);
		}

		if (rb.velocity.y == 0)
		{
			anim.SetBool("isJumping", false);
			//anim.SetBool("isFalling", false);
			//anim.SetBool("isGrounded", false);
		}

		if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0)
			anim.SetBool("isWalking", true);
		   // anim.SetBool("isGrounded", true);

		if (Mathf.Abs(dirX) == 8 && rb.velocity.y == 0)
			anim.SetBool("isRunning", true);
		    
		else
			anim.SetBool("isRunning", false);

        if (Input.GetKey(KeyCode.W) && Mathf.Abs(dirX) == 8)
            anim.SetBool("jumpFlip", true);
		    

		else
            anim.SetBool("jumpFlip", false);

        if (rb.velocity.y > 0)
			anim.SetBool("isJumping", true);
		   //anim.SetBool("isGrounded", false);

		if (rb.velocity.y < 0)
		{
			anim.SetBool("isJumping", false);
			//anim.SetBool("isFalling", true);
			//anim.SetBool("isGrounded", true);
		}
	}

	void CheckWhereToFace()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;

	}

	IEnumerator Hurt()
	{
		isHurting = true;
		rb.velocity = Vector2.zero;

		if (facingRight)
			rb.AddForce(new Vector2(-200f, 200f));
		else
			rb.AddForce(new Vector2(200f, 200f));

		yield return new WaitForSeconds(0.5f);

		isHurting = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Squish")
		{
			//if (!isGrounded)
			//{
			collision.gameObject.GetComponentInParent<EnemyWalker>().IsSquished();
			if (!squishAudioSource)
			{
				squishAudioSource = gameObject.AddComponent<AudioSource>();
				squishAudioSource.clip = squishSFX;
				squishAudioSource.outputAudioMixerGroup = audioMixer;
				squishAudioSource.loop = false;
			}

			squishAudioSource.Play();
		}

		if (collision.gameObject.tag == "PickUp")
		{ 
			if (!pickupAudioSource)
			{
				pickupAudioSource = gameObject.AddComponent<AudioSource>();
				pickupAudioSource.clip = pickUpSFX;
				pickupAudioSource.outputAudioMixerGroup = audioMixer;
				pickupAudioSource.loop = false;
			}

			pickupAudioSource.Play();

			rb.velocity = Vector2.zero;
			rb.AddForce(Vector2.up * bounceForce);
			}
		}
	}

	//public void CollectibleSound(AudioClip pickupAudio)
	//{
	//	pickupAudioSource.clip = pickupAudio;
	//	pickupAudioSource.Play();
	//}

//}
