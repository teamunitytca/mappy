using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour {

	private Animator animator = null;
	int count = 0;

	// Use this for initialization
	void Start ( ) {
		animator = GetComponent< Animator >( );
	}
	
	// Update is called once per frame
	void Update ( ) {

	}
	void OnCollisionEnter2D( Collision2D collision ){

		if ( collision.gameObject.tag == "Player" ) {
			Debug.Log ( "まっぴー" );
			count++;
		}

		animator.SetTrigger ( "Jump" );
		Rigidbody2D hit_obj = collision.gameObject.GetComponent< Rigidbody2D >( );
		hit_obj.velocity = new Vector2 ( 0, 10 );

		if (count == 3) {
			GetComponent< BoxCollider2D >( ).enabled = false;
		}

	}	
}
