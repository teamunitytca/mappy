using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnFactory : MonoBehaviour {
	const int MEOWKIE_MAX = 5;
	const int NYAMCO_MAX = 1;
	int _meowkie_count = 0;
	int _nyamco_count = 0;
	bool _count_time = false;

	float _spawn_timer = 0;
	float _spawn_interval = 0;
	const float SPAWN_NORMAL_TIME = 10;
	const float SPAWN_HARRYUP1_TIME = 8;
	const float SPAWN_HARRYUP2_TIME = 6;

	[SerializeField] GameObject _meowkie = null;
	[SerializeField] GameObject _nyamco = null;
	GameObject [ ] _enemy;

	// Use this for initialization
	void Start( ) {
		_spawn_interval = SPAWN_NORMAL_TIME;
		_spawn_timer = _spawn_interval;
	}

	// Update is called once per frame
	void Update( ) {
		countEnemy( );
		enemySpawn( );
	}

	void countEnemy( ) {
		_nyamco_count = 0;
		_meowkie_count = 0;
		_enemy = GameObject.FindGameObjectsWithTag( "Enemy" );
		for ( int i = 0; i < _enemy.Length; i++ ) {
			if ( _enemy [ i ] ) {
				if ( _enemy [ i ].name.Contains( "Nyamco" ) ) {
					_nyamco_count++;
				}
				if ( _enemy [ i ].name.Contains( "Meowkie" ) ) {
					_meowkie_count++;
				}
			}
		}
	}

	void enemySpawn( ) {
		if ( _count_time ) {
			_spawn_timer -= Time.deltaTime;
		}
		if ( _nyamco_count < NYAMCO_MAX ) {
			_count_time = true;
			if ( _spawn_timer <= 0 ) {
				Instantiate( _nyamco, transform.position, Quaternion.identity );
				_spawn_timer = _spawn_interval;
				_count_time = false;
			}
		}
		if ( _meowkie_count < MEOWKIE_MAX ) {
			_count_time = true;
			if ( _spawn_timer <= 0 ) {
				Instantiate( _meowkie, transform.position, Quaternion.identity );
				_spawn_timer = _spawn_interval;
				_count_time = false;
			}
		}
	}
}
