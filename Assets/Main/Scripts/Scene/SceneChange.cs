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
		if ( _target_scene == "Main" ) {
			NowScore._now_score = 0;
			if ( Input.GetKeyDown( KeyCode.Space ) ) {
				_audio.PlayOneShot( _audio.clip );
				_sound_flag = true;
			}
			if ( !_audio.isPlaying && _sound_flag ) {
				SceneChanger.sceneChange( _target_scene );
			}
		}

		if ( _target_scene == "Title" ) {
			if ( Input.GetKeyDown( KeyCode.Space ) ) {
				SceneChanger.sceneChange( _target_scene );
			}
		}
	}
}
