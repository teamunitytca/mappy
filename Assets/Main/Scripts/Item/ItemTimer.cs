using UnityEngine;

public class ItemTimer : Item {
	const float TIME_INCREMENT = 5.0f;
	Timer _timer;
	// Use this for initialization
	void Start ( ) {
		_timer = GameObject.Find( "TimeText" ).GetComponent<Timer>( );

	}

	// Update is called once per frame
	void Update ( ) {
		
	}

	void OnDestroy ( ) {
		_timer.addTime( TIME_INCREMENT );
	}
}
