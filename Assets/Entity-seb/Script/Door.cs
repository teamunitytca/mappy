﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {
	[SerializeField]
	private bool _isFacingLeft = false;
	[SerializeField]
	private bool _isSpecialDoor = false;

	[SerializeField]
	private GameObject _microWave = null;

	private bool _opened = false;
	private bool _triggerFall = false;
	private Collider2D _collider;

	AudioSource _microwave_se;

	// Use this for initialization
	void Awake( ) {
		_microwave_se = GameObject.Find( "Microwave_SE" ).GetComponent<AudioSource>( );

		this.gameObject.GetComponent<Animator>( ).SetBool( "Opened", _opened );
		_collider = this.gameObject.GetComponent<Collider2D>( );

		if ( _isFacingLeft ) {
			transform.localScale = new Vector3( Mathf.Abs( transform.localScale.x ), transform.localScale.y, transform.localScale.z );
		} else {
			transform.localScale = new Vector3( -Mathf.Abs( transform.localScale.x ), transform.localScale.y, transform.localScale.z );
		}

		if ( _isSpecialDoor ) {
			this.gameObject.GetComponent<Animator>( ).SetBool( "Normal", false );
		} else {
			this.gameObject.GetComponent<Animator>( ).SetBool( "Normal", true );
		}

	}

	public void OpenDoor( ) {
		if ( _isSpecialDoor && !_opened ) {
			_microwave_se.PlayOneShot( _microwave_se.clip );
			GameObject micro = Instantiate( _microWave, transform.position, Quaternion.identity, null ) as GameObject;

			if ( _isFacingLeft ) {
				micro.GetComponent<MicroWave>( ).isFacingLeft = true;
			} else {
				micro.GetComponent<MicroWave>( ).isFacingLeft = false;
			}
		}

		if ( !_isSpecialDoor ) {
			_triggerFall = true;
		}

		_opened = !_opened;
		this.gameObject.GetComponent<Animator>( ).SetBool( "Opened", _opened );
	}

	private void OnCollisionEnter2D( Collision2D collision ) {
		if ( _opened ) {
			Physics2D.IgnoreCollision( collision.collider, _collider );
		}
	}

	private void OnCollisionStay2D( Collision2D collision ) {
		if ( _opened ) {
			Physics2D.IgnoreCollision( collision.collider, _collider );
		}
	}

	private void OnTriggerEnter( Collider other ) {
		if ( _triggerFall && other.gameObject.tag == "Enemy" || _triggerFall && other.gameObject.tag == "Player" ) {
			other.gameObject.GetComponent<Entity>( ).Falled( );
			_triggerFall = false;
		}
	}

	public override void Use( GameObject entity ) {
		if ( _isFacingLeft && entity.transform.position.x > this.transform.position.x ) {
			OpenDoor( );
		} else if ( !_isFacingLeft && entity.transform.position.x < this.transform.position.x ) {
			OpenDoor( );
		}
	}
}
