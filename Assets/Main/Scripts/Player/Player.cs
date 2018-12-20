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
        if (Input.GetButton("Horizontal") && _movable)
        {
			if ( Input.GetAxis( "Horizontal" ) < 0 ) {
				_state = MOVING.LEFT;
			} else {
				_state = MOVING.RIGTH;
			}
        }
        else if (_state != MOVING.JUMP)
        {
            _state = MOVING.IDLE;
        }
    }

    void FixedUpdate( )
    {
        Move();
	}

	void OnBecameInvisible( ) {
		_life.loseLife( );
		resetPos( );
		_rigidbody.velocity = Vector2.zero;
	}

	void resetPos( ) {
		if ( _startPos != null ) {
			transform.position = _startPos.transform.position;
		}
	}

	void OnCollisionEnter2D( Collision2D collision )
    {
		if (collision.gameObject.tag == "Enemy")
        {
			_life.loseLife( );
			resetPos( );
		}
		_movable = true;
	}

	void OnCollisionExit2D(Collision2D collision)
    {
		//to do, somthing importent
	}
}
