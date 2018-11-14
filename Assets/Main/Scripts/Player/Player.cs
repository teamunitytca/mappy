using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] bool _movable = true;
	[SerializeField] float _speed = 0;
	[SerializeField] GameObject _startPos = null;
	Rigidbody2D _rb;
	LifeCounter _life;

	// Use this for initialization
	void Start ( ) {
		_rb = GetComponent<Rigidbody2D>( );
		_life = GameObject.Find( "LifeCounter" ).GetComponent<LifeCounter>( );
	}

	// Update is called once per frame
	void Update ( ) {
		if ( _movable ) {
			move( );
		}
		if ( transform.position.y <= -5 ) {
			_life.loseLife( );
			resetPos( );
		}
	}

	void move ( ) {
		float move = Input.GetAxisRaw( "Horizontal" );
		transform.position += new Vector3( move * _speed, 0, 0 ) * Time.deltaTime;
		if ( move < 0 ) {
			transform.localScale = new Vector3( 5, 5, 1 );
		}
		if ( move > 0 ) {
			transform.localScale = new Vector3( -5, 5, 1 );
		}

	}

	void jump ( ) {
		_movable = false;
		_rb.velocity = new Vector2( 50, 250 ) * Time.deltaTime;
	}

	void resetPos ( ) {
		transform.position = _startPos.transform.position;
	}

	void OnCollisionEnter2D ( Collision2D collision ) {
		if ( collision.gameObject.tag == "Enemy" ) {
			_life.loseLife( );
			resetPos( );
		}
		_movable = true;
	}

	void OnCollisionExit2D ( Collision2D collision ) {
		if ( collision.gameObject.tag == "Floor" ) {
			jump( );
		}
	}
}
