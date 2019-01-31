using UnityEngine;
using UnityEngine.UI;

public class NowScore : MonoBehaviour {
	public static int _now_score = 0;
	[SerializeField] Text _text = null;

	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			_now_score+= 10000;
		}
		_text.text = "NOW SCORE" + "\n" + _now_score.ToString( "D2" );
	}

	public void addScore ( int score ) {
		_now_score += score;
	}

	public int getScore ( ) {
		return _now_score;
	}
}
