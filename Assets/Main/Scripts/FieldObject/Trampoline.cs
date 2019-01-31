using UnityEngine;

public class Trampoline : MonoBehaviour {
	const int TRAMPOLINE_MAXHP = 4;
	int _trampoline_HP = TRAMPOLINE_MAXHP;

	bool _ontop;
	Collider2D [ ] _col;
	Animator _trampoline_anim;

	[SerializeField]
	Vector2 _velocity = Vector2.zero;

	[SerializeField] int _trampoline_no = 0;

	// Use this for initialization
	void Start( ) {
		_ontop = false;
		_col = GetComponents<Collider2D>( );
		_trampoline_anim = GetComponent<Animator>( );
		_trampoline_anim.SetInteger( "NO", _trampoline_no );
	}

	// Update is called once per frame
	void Update( ) {
		if ( _trampoline_HP <= 0 ) {
			changeColor( );
			_col [ 1 ].isTrigger = true;
			return;
		}

		_col [ 1 ].isTrigger = false;
	}

	void changeColor( ) {
		_trampoline_anim.SetInteger( "HP", _trampoline_HP );
	}

	void OnCollisionEnter2D( Collision2D collision ) {
		if ( _ontop && ( collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" ) ) {
			_trampoline_anim.SetBool( "OnBound", true );
			collision.gameObject.GetComponent<Entity>( ).SetState( Entity.MOVING.JUMP );
		}
	}

	void OnCollisionStay2D( Collision2D collision ) {
		if ( _ontop && ( collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" ) ) {
			_trampoline_anim.SetBool( "OnBound", true );
			collision.gameObject.GetComponent<Entity>( ).SetState( Entity.MOVING.JUMP );
		}
	}

	void OnTriggerEnter2D( Collider2D collision ) {
		_ontop = true;
	}

	void OnTriggerExit2D( Collider2D collision ) {
		_ontop = false;
		_trampoline_anim.SetBool( "OnBound", false );

		if ( collision.gameObject.tag == "Player" ) {
			_trampoline_HP--;
		}
	}

	public void resetTrampolineHP( ) {
		_trampoline_HP = TRAMPOLINE_MAXHP;
	}
}
