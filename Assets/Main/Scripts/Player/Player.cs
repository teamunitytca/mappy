using UnityEngine;

public class Player : Entity {
	GameObject _startPos = null;
	GameObject _trampolin = null;
	LifeCounter _life = null;
	[SerializeField]
	Animator _anim = null;

	[SerializeField] uint _currentFloor;
	[SerializeField] uint _prevFloor;



	// Use this for initialization
	void Start( ) {
		_life = GameObject.Find( "LifeCounter" ).GetComponent<LifeCounter>( );
		_startPos = GameObject.Find( "StartPos" );
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
		if ( _startPos != null ) 
		{
			transform.position = _startPos.transform.position;
		}
	}

	void OnCollisionEnter2D( Collision2D collision ) 
	{
		if ( collision.gameObject.tag == "Enemy" ) {
			_life.loseLife( );
			resetPos( );
		}
		if ( collision.gameObject.tag == "Floor" && _trampolin != null ) {
			_trampolin.gameObject.GetComponent<Trampoline>( ).resetTrampolineHP( );
			_trampolin = null;
		}
		_movable = true;
	}

	void OnTriggerEnter2D( Collider2D collision ) {
		if ( collision.gameObject.tag == "Trampolin" ) {
			_trampolin = collision.gameObject;
		}
	}

	public void SetCurrentFloor( uint floor ) {
		_prevFloor = _currentFloor;
		_currentFloor = floor;
	}

	public uint GetCurrentFloor( ) {
		return _currentFloor;
	}

	public uint GetPrevFloor( ) {
		return _prevFloor;
	}
}
