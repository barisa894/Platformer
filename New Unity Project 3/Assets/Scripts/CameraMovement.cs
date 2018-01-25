using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	[SerializeField]
	private float xMax;

	[SerializeField]
	private float yMax;

	[SerializeField]
	private float xMin;

	[SerializeField]
	private float yMin;

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;
		//Debug.Log (target);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y, yMin, yMax),transform.position.z);
		//Debug.Log (target.position);
	
	}
}
