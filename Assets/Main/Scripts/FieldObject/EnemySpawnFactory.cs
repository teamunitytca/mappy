using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnFactory : MonoBehaviour {
	float _spawn_timer = 0;
	float _spawn_interval = 0;
	const float SPAWN_NORMAL_TIME = 10;
	const float SPAWN_HARRYUP1_TIME = 8;
	const float SPAWN_HARRYUP2_TIME = 6;

	[SerializeField] GameObject _meowkie = null;
	[SerializeField] GameObject _nyamco = null;

	// Use this for initialization
	void Start( ) {
		_spawn_interval = SPAWN_NORMAL_TIME;
		_spawn_timer = _spawn_interval;
	}

	// Update is called once per frame
	void Update( ) {
		_spawn_timer -= Time.deltaTime;
		if ( _spawn_timer <= 0 ) {
			Instantiate( _meowkie, transform.position, Quaternion.identity );
			_spawn_timer = _spawn_interval;
		}
	}
}
