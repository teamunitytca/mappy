using UnityEngine;

public class Player : Entity {
	GameObject _startPos = null;
	GameObject _trampolin = null;
	LifeCounter _life = null;
	[SerializeField] Animator _anim = null;

	[SerializeField] uint _currentFloor;
	[SerializeField] uint _prevFloor;

	const float REVIVAL_TIME = 2;
	[SerializeField] float _revival_timer = 0;
	bool _revival_flag = false;

	LayerMask _player_layer;
	LayerMask _enemy_layer;

	// Use this for initialization
	void Start( ) {
		_life = GameObject.Find( "LifeCounter" ).GetComponent<LifeCounter>( );
		_startPos = GameObject.Find( "StartPos" );
		_player_layer = LayerMask.NameToLayer( "Player" );
		_enemy_layer = LayerMask.NameToLayer( "Enemy" );
	}

	private void Update( ) {
		updateState( );
		updateAnimState( );
		revival( );
	}

	void FixedUpdate( ) {
		Move( );

		if (_rigidbody.velocity.y > 0.01f)
			ignoreDeath = true;
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
		if ( transform.position.y <= -0.7f ) {
			_life.loseLife( );
			resetPos( );
			_rigidbody.velocity = Vector2.zero;
			_revival_flag = true;
			_revival_timer = REVIVAL_TIME;
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
		if ( _startPos ) {
			transform.position = _startPos.transform.position;
		}
	}

	void revival( ) {
		if ( _revival_flag ) {
			if ( _revival_timer > 0 ) {
				Physics2D.IgnoreLayerCollision( _player_layer, _enemy_layer, true );
				_revival_timer -= Time.deltaTime;
				GetComponent<SpriteRenderer>( ).enabled = !GetComponent<SpriteRenderer>( ).enabled;
			}
			if ( _revival_timer <= 0 ) {
				Physics2D.IgnoreLayerCollision( _player_layer, _enemy_layer, false );
				_revival_flag = false;
				GetComponent<SpriteRenderer>( ).enabled = true;
			}
		}
	}

	void OnCollisionEnter2D( Collision2D collision ) {
		if ( collision.gameObject.tag == "Enemy"  && !ignoreDeath) {
			_life.loseLife( );
			resetPos( );
			_revival_flag = true;
			_revival_timer = REVIVAL_TIME;
		}
		if ( collision.gameObject.tag == "Floor" && _trampolin != null ) {
			_trampolin.gameObject.GetComponent<Trampoline>( ).resetTrampolineHP( );
			_trampolin = null;
		}
		if ( collision.gameObject.tag == "Floor" ) {
			Physics2D.IgnoreLayerCollision( _player_layer, _enemy_layer, false );
		}
		_movable = true;
	}

	void OnTriggerEnter2D( Collider2D collision ) {
		if ( collision.gameObject.tag == "Trampolin" ) {
			_trampolin = collision.gameObject;
			Physics2D.IgnoreLayerCollision( _player_layer, _enemy_layer, true );
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
