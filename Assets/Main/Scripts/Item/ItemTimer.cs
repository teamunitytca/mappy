using UnityEngine;

public class ItemTimer : Item {
	const float TIME_INCREMENT = 5.0f;
	Timer _timer;
	AudioSource _item_se;
	void Start( ) {
		_item_se = GameObject.Find( "Item_SE" ).GetComponent<AudioSource>( );
		_timer = GameObject.Find( "TimeText" ).GetComponent<Timer>( );
	}

	void OnDestroy( ) {
		if ( _item_se ) {
			_item_se.PlayOneShot( _item_se.clip );
		}
		_timer.addTime( TIME_INCREMENT );
	}
}
