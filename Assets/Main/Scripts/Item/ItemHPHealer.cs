using UnityEngine;

public class ItemHPHealer : Item
{
	LifeCounter _life = null;
    
	void Start ( ) {
		_life = GameObject.Find( "LifeCounter" ).GetComponent<LifeCounter>( );
	}

	void OnDestroy ( ) {
		_life.addLife( );
	}
}
