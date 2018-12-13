using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class trampoline : MonoBehaviour {
	protected enum HP {
		green = 0,
		blue = 1,
		yellow = 2,
		red = 3
	}

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
		
		animator.SetTrigger ( "Jump" );
		animator.SetInteger ("HP", (int)HP.green);
		Rigidbody2D hit_obj = collision.gameObject.GetComponent< Rigidbody2D >( );
		hit_obj.velocity = new Vector2 ( 0, 10 );

		if ( collision.gameObject.tag == "Player" ) {
			Debug.Log ( "まっぴー" );
			count++;
		}

		if (count == 1) {
			animator.SetInteger ("HP", (int)HP.blue);
		}else if (count == 2) {
			animator.SetInteger ("HP", (int)HP.yellow);
		}else if (count == 3) {
			animator.SetInteger ("HP", (int)HP.red);
			GetComponent< BoxCollider2D >( ).enabled = false;
		}
	}	
}
