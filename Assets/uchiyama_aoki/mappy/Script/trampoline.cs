using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class trampoline : MonoBehaviour {
	protected enum HP {
		green = 3,
		blue = 2,
		yellow = 1,
		red = 0
	}

private Animator animator = null;
	int count = 0;

	// Use this for initialization
	void Start ( ) {
		animator = GetComponent< Animator >( );
		animator.SetInteger ("HP", (int)HP.green);
	}
	
	// Update is called once per frame
	void Update ( ) {

	}
	void OnCollisionEnter2D( Collision2D collision ){

		animator.SetTrigger ( "Jump" );
		Rigidbody2D hit_obj = collision.gameObject.GetComponent< Rigidbody2D >( );
		hit_obj.velocity = new Vector2 ( 0, 200 ) * Time.deltaTime;

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
			GetComponent< BoxCollider2D >( ).isTrigger = true;
		}

	}
	void OnTriggerEnter2D(Collider2D collision) {
		animator.SetBool ( "Dead", true );
		Debug.Log("hit");
	}
		
}
