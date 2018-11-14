using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	int _high_score = 0;
	[SerializeField] Text _text = null;
	[SerializeField] NowScore _score = null; 

	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {
		if ( _score.getScore( ) >= _high_score ) {
			_high_score = _score.getScore( );
		}
		_text.text = "HIGH SCORE" + "\n" + _high_score.ToString( "D2" );
	}
}
