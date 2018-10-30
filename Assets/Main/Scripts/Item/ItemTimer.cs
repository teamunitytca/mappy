using UnityEngine;

public class ItemTimer : Item {
	[SerializeField] Timer _timer = null;
	const float TIME_INCREMENT = 5.0f;
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
