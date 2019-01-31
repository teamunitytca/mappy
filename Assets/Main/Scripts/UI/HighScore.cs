using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour {
	public static int _high_score = 20000;
	[SerializeField] Text _text = null;
	[SerializeField] NowScore _score = null;

	// Use this for initialization
	void Start( ) {
	}

	// Update is called once per frame
	void Update( ) {
		if ( SceneManager.GetActiveScene( ).name == "Main" ) {
			if ( _score.getScore( ) >= _high_score ) {
				_high_score = _score.getScore( );
			}
		}
		
		_text.text = "HI SCORE" + "\n" + _high_score.ToString( "D2" );
	}
}
