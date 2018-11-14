﻿using UnityEngine;

public class Trampoline : MonoBehaviour {
	const int TRAMPOLINE_MAXHP = 4;
	int _trampoline_HP = TRAMPOLINE_MAXHP;
	bool _ontop;
	GameObject _bouncer;
	Collider2D [ ] _col;
	Animator _trampoline_anim;
	[SerializeField] Vector2 _velocity = Vector2.zero;

	// Use this for initialization
	void Start ( ) {
		_ontop = false;
		_col = GetComponents<Collider2D>( );
		_trampoline_anim = GetComponent<Animator>( );
	}

	// Update is called once per frame
	void Update ( ) {
		if ( _trampoline_HP <= 0 ) {
			_col [ 1 ].isTrigger = true;
			return;
		}

		_col [ 1 ].isTrigger = false;

	}

	void OnCollisionEnter2D ( Collision2D collision ) {
		if ( collision.gameObject.tag == "Player" ) {
			_trampoline_HP--;
		}
	}

	void OnCollisionStay2D ( Collision2D collision ) {
		if ( _ontop && collision.gameObject.tag == "Player" ) {
			_trampoline_anim.SetBool( "OnBound", true );
			_bouncer = collision.gameObject;
		}
	}

	void OnTriggerEnter2D ( Collider2D collision ) {
		_ontop = true;
	}

	void OnTriggerExit2D ( Collider2D collision ) {
		_ontop = false;
		_trampoline_anim.SetBool( "OnBound", false );
	}

	void jump ( ) {
		_bouncer.GetComponent<Rigidbody2D>( ).velocity = _velocity * Time.deltaTime;
	}

	public void resetTrampolineHP ( ) {
		_trampoline_HP = TRAMPOLINE_MAXHP;
	}
}