using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	[SerializeField] int _high_score = 1000;
	[SerializeField] Text _text = null;

	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {
		_text.text = "HIGH SCORE" + "\n" + _high_score.ToString( "D2" );

	}
}
