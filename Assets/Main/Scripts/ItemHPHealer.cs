using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHPHealer : Item {
	[SerializeField] LifeCounter _life = null;
	// Use this for initialization
	void Start ( ) {
		_life = GameObject.Find( "LifeCounter" ).GetComponent<LifeCounter>( );
	}

	// Update is called once per frame
	void Update ( ) {

	}

	void OnDestroy ( ) {
		_life.addLife( );
	}
}
