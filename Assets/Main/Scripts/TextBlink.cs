using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour {
	float _time = 0;
	float _blink_speed = 3.0f;
	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {
		_time += Time.deltaTime * _blink_speed;
		blink( _time );
	}

	void blink ( float time ) {
		float alpha = 0.5f * ( Mathf.Sin( time ) + 1 );
		GetComponent<Text>( ).color = new Color( 1f, 1f, 1f, alpha );
	}
}
