using UnityEngine;
using UnityEngine.UI;

public class NowScore : MonoBehaviour {
	[SerializeField] int _now_score = 0;
	[SerializeField] Text _text = null;

	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {
		_text.text = "NOW SCORE" + "\n" + _now_score.ToString( "D2" );

	}
}
