using UnityEngine;
using UnityEngine.SceneManagement;

public class MargeScene : MonoBehaviour {

	// Use this for initialization
	void Start ( ) {
		margeScene( "Stage" );
	}

	// Update is called once per frame
	void Update ( ) {

	}

	void margeScene ( string scene ) {
		SceneManager.LoadScene( scene, LoadSceneMode.Additive );

	}
}
