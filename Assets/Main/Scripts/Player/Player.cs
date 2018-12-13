using UnityEngine;

public class Player : Entity
{
	[SerializeField]
    GameObject _startPos = null;
	LifeCounter _life;

	// Use this for initialization
	void Start()
    {
		_life = GameObject.Find( "LifeCounter" ).GetComponent<LifeCounter>( );
	}

    private void Update()
    {
        _move_input = Input.GetAxisRaw("Horizontal");

        if (_move_input < 0 && _movable)
        {
            _state = MOVING.LEFT;
        }

        if (_move_input > 0 && _movable)
        {
            _state = MOVING.RIGTH;
        }

        if (_move_input == 0 || !_movable)
        {
            _state = MOVING.IDLE;
        }
    }

    void FixedUpdate( )
    {
        Move();

        if (transform.position.y < -3)
        {
            _life.loseLife();
            transform.position = _startPos.transform.position;
        }
	}

	void resetPos( ) {
		transform.position = _startPos.transform.position;
	}

	void OnCollisionEnter2D( Collision2D collision ) {
		if ( collision.gameObject.tag == "Enemy" ) {
			_life.loseLife( );
			resetPos( );
		}
		_movable = true;
	}

	void OnCollisionExit2D(Collision2D collision) {
        Jump(collision);
	}
}
