using UnityEngine;
using System.Collections;

public class BossPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveLeft;
	private Rigidbody2D rigid;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	private bool facingRight;
	
	private bool notatEdge;
	public Transform edgeCheck;

	private float ySize;
	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D> ();

		ySize = transform.localScale.y;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{ 
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		notatEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);
		
		if (hittingWall || !notatEdge) 
			moveLeft = !moveLeft;
		if(moveLeft)
		{
			transform.localScale = new Vector3(-ySize,transform.localScale.y,transform.localScale.z);
			rigid.velocity = new Vector2(moveSpeed,rigid.velocity.y);
		}
		else {
			transform.localScale = new Vector3(ySize,transform.localScale.y,transform.localScale.z);
			rigid.velocity = new Vector2(-moveSpeed,rigid.velocity.y);
			
		}
		
	}
}
