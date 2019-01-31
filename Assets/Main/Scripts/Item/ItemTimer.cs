using UnityEngine;

public class ItemTimer : Item
{
	const float TIME_INCREMENT = 5.0f;
	Timer _timer;

	void Start ( )
    {
		_timer = GameObject.Find( "TimeText" ).GetComponent<Timer>( );
	}

	void OnDestroy ( ) {
		_timer.addTime( TIME_INCREMENT );
	}
}
