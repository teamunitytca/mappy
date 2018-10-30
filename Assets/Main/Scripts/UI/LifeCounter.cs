using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {
	[SerializeField] int _HP = 2;
	[SerializeField] Image[ ] _life_counter = null;

	const int HP_MAX = 5;
	
	// Use this for initialization
	void Start ( ) {
		for ( int i = 0; i < _life_counter.Length; i++ ) {
			_life_counter[ i ] = transform.GetChild( i ).gameObject.GetComponent<Image>( );
		}
	}
	 
	// Update is called once per frame
	void Update ( ) {
		for ( int i = 0; i < _life_counter.Length; i++ ) {
			_life_counter[ i ].enabled = false;
		}
		for ( int i = 0; i < _HP; i++ ) {
			_life_counter[ i ].enabled = true;
		}

		if ( _HP <= 0 ) {
			SceneChanger.sceneChange( "Result" );
		}
	}

	public void addLife ( ) {
		_HP++;
		if ( _HP > HP_MAX ) {
			_HP = HP_MAX;
		}
	}

	public void loseLife ( ) {
		_HP--;
	}
}
