using UnityEngine;

public class Player : Entity {
	[SerializeField]
	GameObject _startPos = null;
	LifeCounter _life = null;
	[SerializeField]
	Animator _anim = null;

	// Use this for initialization
	void Start( ) {
		_life = GameObject.Find( "LifeCounter" ).GetComponent<LifeCounter>( );
	}

	private void Update( ) {
		updateState( );
		updateAnimState( );
	}

	void FixedUpdate( ) {
		Move( );
	}

	void OnBecameInvisible( ) {
		_life.loseLife( );
		resetPos( );
		_rigidbody.velocity = Vector2.zero;
	}

	void updateState( ) {
		if ( Input.GetButton( "Horizontal" ) && _movable ) {
			if ( Input.GetAxis( "Horizontal" ) < 0 ) {
				_state = MOVING.LEFT;
			} else {
				_state = MOVING.RIGTH;
			}
		} else if ( _state != MOVING.JUMP ) {
			_state = MOVING.IDLE;
		}
	}

	void updateAnimState( ) {
		_anim.SetBool( "HitDoor", false );
		_anim.SetBool( "Move", false );
		_anim.SetBool( "Jump", false );
		_anim.SetBool( "Died", false );
		switch ( _anim_state ) {
			case ANIM_STATE.IDLE:
				break;
			case ANIM_STATE.MOVE:
				_anim.SetBool( "Move", true );
				break;
			case ANIM_STATE.JUMP:
				_anim.SetBool( "Jump", true );
				break;
			case ANIM_STATE.HIT_DOOR:
				_anim.SetBool( "HitDoor", true );
				break;
			case ANIM_STATE.DIED:
				_anim.SetBool( "Died", true );
				break;
		}
	}

	void resetPos( ) {
		if ( _startPos != null ) {
			transform.position = _startPos.transform.position;
		}
	}

	void OnCollisionEnter2D( Collision2D collision ) {
		if ( collision.gameObject.tag == "Enemy" ) {
			_life.loseLife( );
			resetPos( );
		}
		_movable = true;
	}

	void OnCollisionExit2D( Collision2D collision ) {
		//to do, somthing importent
	}
}
