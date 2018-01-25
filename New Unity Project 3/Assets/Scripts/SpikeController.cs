using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {

	public float moveSpeed;
	public bool moveUp;
	private Rigidbody2D rigid;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGrounded;
	private bool grounded;

	
	private bool notatEdge;
	public Transform edgeCheck;
	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{ 
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGrounded);
		notatEdge =Physics2D.OverlapCircle (edgeCheck.position, groundCheckRadius, whatIsGrounded);
		
		if (grounded || !notatEdge) 
			moveUp = !moveUp;
		if(moveUp)
		{
			transform.localScale = new Vector3(1f,1f,1f);
			rigid.velocity = new Vector2(0f,-1f);
		}
		else {
			transform.localScale = new Vector3(-1f,1f,1f);
			rigid.velocity = new Vector2(0f,1f);
			
		}
		transform.Rotate ((new Quaternion(5,5,5,0).eulerAngles));
	}
}
