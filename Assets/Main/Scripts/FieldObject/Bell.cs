using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour {
	Rigidbody2D _rb;
	LayerMask _bell;
	LayerMask _enemy;
	EnemyBellCollision _bellCollision;
	// Use this for initialization
	void Start ( ) {
		_rb = GetComponent<Rigidbody2D>( );
		_rb.gravityScale = 0;

		_bell = LayerMask.NameToLayer( "Bell" );
		_enemy = LayerMask.NameToLayer( "Enemy" );
		Physics2D.IgnoreLayerCollision( _bell, _enemy, true );
	}

	// Update is called once per frame
	void Update ( ) {

	}

	void OnTriggerEnter2D ( Collider2D collision ) {
		if ( collision.tag == "Player" ) {
			_rb.gravityScale = 1;
			_bell = LayerMask.NameToLayer( "Bell" );
			_enemy = LayerMask.NameToLayer( "Enemy" );
			Physics2D.IgnoreLayerCollision( _bell, _enemy, false );
		}

		if ( collision.tag == "Enemy" ) {
			_bellCollision = collision.gameObject.GetComponent<EnemyBellCollision>( );
			_bellCollision.setMovable( false );
		}
	}
}
