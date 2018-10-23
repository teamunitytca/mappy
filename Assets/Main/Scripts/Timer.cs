using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	[SerializeField] float _time_limit;
	[SerializeField] Text _text = null;

	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {

		_time_limit -= Time.deltaTime;
		_text.text = "TIME" + "\n" + ( ( int )_time_limit ).ToString( );

		if ( _time_limit <= 0 ) {
			SceneChanger.sceneChange( "Result" );
		}
	}

	public void addTime ( float time ) {
		_time_limit += time;
	}
}
