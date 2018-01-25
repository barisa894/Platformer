using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float moveSpeed;
	private float moveVelocity;

	private Rigidbody2D rb2d;

	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGrounded;
	private bool grounded;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	private bool doubleJumped;

	private Animator myAnimator;

	private bool slide;


	public bool onLadder;   //for ladder
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	public Transform firePoint;
	public GameObject star;

	public float shotDelay;
	private float shotDelayCounter;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		myAnimator= GetComponent<Animator> ();

		gravityStore = rb2d.gravityScale;
	}

	// Update is called once per frame
	void FixedUpdate () 

	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGrounded);

	}




	void Update()
	{
		if (grounded)
			doubleJumped = false;




		myAnimator.SetBool ("Grounded", grounded);

		myAnimator.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));

#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown ("Jump") && grounded) {
			//rb2d.velocity = new Vector2 (rb2d.velocity.x,jumpHeight);
			//Jump ();
		}
		if (Input.GetButtonDown ("Jump") && !grounded && !doubleJumped) {
			//rb2d.velocity = new Vector2 (rb2d.velocity.x,jumpHeight);
			Jump ();
			doubleJumped = true;
		}
		if (Input.GetButtonDown ("Fire1")) {
			Instantiate(star,firePoint.position,firePoint.rotation);
			FireStar ();
			shotDelayCounter = shotDelay;
		}

		if (Input.GetButton ("Fire1")) {
			shotDelayCounter -= Time.deltaTime;

			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				Instantiate(star,firePoint.position,firePoint.rotation);
				FireStar ();
			}
		}





		moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

		Move(Input.GetAxisRaw("Horizontal"));
		if (rb2d.velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if (rb2d.velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);

		if (knockbackCount <= 0) {
			rb2d.velocity = new Vector2 (moveVelocity, rb2d.velocity.y);

		} else {
			if (knockFromRight) //left
				rb2d.velocity = new Vector2 (-knockback, knockback);
			if (!knockFromRight)
				rb2d.velocity = new Vector2 (knockback, knockback);

			knockbackCount -= Time.deltaTime;
		}


	




	

#endif

			if (onLadder) 
			{
				rb2d.gravityScale = 0f;
				climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");
				rb2d.velocity = new Vector2 (rb2d.velocity.x, climbVelocity);
			}

			if (!onLadder)
			{
				rb2d.gravityScale = gravityStore;
			}
		}


	public void Move(float moveInput)
	{
		moveVelocity = moveSpeed * moveInput;
		rb2d.velocity = new Vector2 (moveVelocity, rb2d.velocity.y);
	}

	public void FireStar()
	{
		Instantiate(star,firePoint.position,firePoint.rotation);
	}

	public void Jump()
	{
		//rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight);
		if (grounded) 
		{
			//rb2d.velocity = new Vector2 (rb2d.velocity.x,jumpHeight);
			//Jump ();
			rb2d.velocity = new Vector2 (rb2d.velocity.x,jumpHeight);
		}
		if (!grounded && !doubleJumped) 
		{
			//rb2d.velocity = new Vector2 (rb2d.velocity.x,jumpHeight);
			//Jump ();
			rb2d.velocity = new Vector2 (rb2d.velocity.x,jumpHeight);
			doubleJumped = true;
		}
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = other.transform; //parent of the platform
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;//parent of the platform
		}
	}
}

