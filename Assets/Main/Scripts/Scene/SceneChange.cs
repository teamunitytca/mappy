using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour {

	[SerializeField] string _target_scene = null;
	[SerializeField] AudioSource _audio = null;
	bool _sound_flag = false;

	// Use this for initialization
	void Start( ) {

	}

	// Update is called once per frame
	void Update( ) {
		if ( Input.anyKeyDown ) {
			_audio.PlayOneShot( _audio.clip );
			_sound_flag = true;
		}
		if ( !_audio.isPlaying && _sound_flag && _target_scene == "Title" ) {
			SceneChanger.sceneChange( _target_scene );
		}
	}
}
