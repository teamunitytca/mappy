using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBellCollision : MonoBehaviour {
	const float FREEZE_TIME = 5.0f;
	bool _movable;
	float _timer;

	// Use this for initialization
	void Start ( ) {
		_movable = true;
		_timer = FREEZE_TIME;
	}

	// Update is called once per frame
	void Update ( ) {
		if ( !_movable ) {
			_timer -= Time.deltaTime;
		}

		if ( _timer <= 0 ) {
			_movable = true;
			_timer = FREEZE_TIME;
		}
	}

	public void setMovable ( bool movable ) {
		_movable = movable;
	}

	public bool getMovable ( )  {
		return _movable;
	}
}
