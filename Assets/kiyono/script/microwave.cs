using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microwave : MonoBehaviour {

	Rigidbody2D rb;
	public int moveSpeed = 5;


	void Start () {
		
	
		rb = GetComponent<Rigidbody2D>();

	}
	

	void Update () {
		
		if (Input.GetMouseButtonDown (0)) 
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
		
	}
}
