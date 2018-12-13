using UnityEngine;

public class Player : MonoBehaviour {
	float _move_input = 0;
	[SerializeField] bool _movable = true;
	[SerializeField] float _speed = 0;
	[SerializeField] GameObject _startPos = null;
	Rigidbody2D _rb;
	LifeCounter _life;

	// Use this for initialization
	void Start( ) {
		_rb = GetComponent<Rigidbody2D>( );
		_life = GameObject.Find( "LifeCounter" ).GetComponent<LifeCounter>( );
	}

	// Update is called once per frame
	void Update( ) {
		if ( _movable ) {
			move( );
		}
		if ( transform.position.y <= -5 ) {
			_life.loseLife( );
			resetPos( );
		}
	}

	void move( ) {
		_move_input = Input.GetAxisRaw( "Horizontal" );
		transform.position += new Vector3( _move_input * _speed, 0, 0 ) * Time.deltaTime;
		if ( _move_input < 0 ) {
			transform.localScale = new Vector3( Mathf.Abs( transform.localScale.x ), transform.localScale.y, transform.localScale.z );
		}
		if ( _move_input > 0 ) {
			transform.localScale = new Vector3( -Mathf.Abs( transform.localScale.x ), transform.localScale.y, transform.localScale.z );
		}

	}

	void jump( ) {
		_movable = false;
		if ( _move_input < 0 ) {
			_rb.velocity = new Vector2( -50, 250 ) * Time.deltaTime;
		}
		if ( _move_input > 0 ) {
			_rb.velocity = new Vector2( 50, 250 ) * Time.deltaTime;
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

	void OnCollisionExit2D( Collision2D collision ) {
		if ( collision.gameObject.tag == "Floor" ) {
			jump( );
		}
	}
}
