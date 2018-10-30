using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour {

	[SerializeField] string _target_scene;

	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {
		if ( Input.anyKey ) {
			SceneChanger.sceneChange( _target_scene );
		}
	}
}
