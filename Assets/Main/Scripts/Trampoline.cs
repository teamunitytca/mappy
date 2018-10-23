using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {
	int _HP = 3;

	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {

	}

	void OnCollisionEnter2D ( Collision2D collision ) {
		if ( gameObject.tag == "Player" ) {
			_HP--;
		}
	}

	public void resetHP ( ) {
		_HP = 3;
	}
}
