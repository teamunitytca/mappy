using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour {
	[SerializeField] int _HP = 2;
	[SerializeField] GameObject[ ] _life_counter = null;
	const int HP_MAX = 5;
	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {
		for ( int i = 0; i < _life_counter.Length; i++ ) {
			_life_counter[ i ].SetActive( false );
		}
		for ( int i = 0; i < _HP; i++ ) {
			_life_counter[ i ].SetActive( true );
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
