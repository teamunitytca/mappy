using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	[SerializeField] int _high_score = 1000;
	[SerializeField] int _now_score = 0;
	[SerializeField] Text _text = null;

	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {
		_text.text = "SCORE" + "\n" +
					 "<size=30>HI</size>     " + _high_score.ToString( "D2" ).PadLeft( 7, ' ' ) + "\n" +
					 "<size=30>NOW</size>    " + _now_score.ToString( "D2" ).PadLeft( 7, ' ' );

	}
}
