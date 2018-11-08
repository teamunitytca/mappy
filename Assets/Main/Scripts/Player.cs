using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField] GameObject _startPos = null;
	[SerializeField] float _speed = 0;
	[SerializeField] float _jump_power = 0;
	Rigidbody2D _rb;
	LifeCounter _life;

	// Use this for initialization
	void Start ( ) {
		_rb = GetComponent<Rigidbody2D>( );
		_life = GameObject.Find("LifeCounter").GetComponent<LifeCounter>( );
	}

	// Update is called once per frame
	void Update ( ) {
		move( );
		if ( transform.position.y <= -5 ) {
			_life.loseLife( );
			resetPos( );
		}
	}

	void move ( ) {
		float move = Input.GetAxisRaw( "Horizontal" );
		transform.position += new Vector3( move * _speed, 0, 0 ) * Time.deltaTime;
	}

	void jump ( ) {
		_rb.AddForce( Vector2.up * _jump_power );
	}

	void resetPos ( ) {
		transform.position = _startPos.transform.position;
	}

	void OnCollisionEnter2D ( Collision2D collision ) {
		if ( collision.gameObject.tag == "Enemy" ) {
			_life.loseLife( );
			resetPos( );
		}
	}
}
