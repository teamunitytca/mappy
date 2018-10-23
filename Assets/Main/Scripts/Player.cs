using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] float _speed = 0;
	[SerializeField] float _jump_power = 0;
	Rigidbody2D _rb;
	bool isjump;

	// Use this for initialization
	void Start ( ) {
		_rb = GetComponent<Rigidbody2D>( );
		isjump = true;

	}

	// Update is called once per frame
	void Update ( ) {
		move( );
		jump( );
	}

	void move ( ) {
		float move = Input.GetAxisRaw( "Horizontal" );
		transform.position += new Vector3( move * _speed, 0, 0 ) * Time.deltaTime;
	}

	void jump ( ) {
		if ( Input.GetButtonDown( "Jump" ) && !isjump ) {
			_rb.AddForce( Vector2.up * _jump_power );
			isjump = true;
		}
	}

	void OnCollisionEnter2D ( Collision2D collision ) {
		isjump = false;
	}

}
