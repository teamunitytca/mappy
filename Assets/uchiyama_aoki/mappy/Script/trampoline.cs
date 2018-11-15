using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour {

	private Animator animator = null;
	public Rigidbody2D player;

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
			animator.SetTrigger ( "Jump" );
			player.velocity = new Vector2 ( 0, 10 );
		}
	}	
}
