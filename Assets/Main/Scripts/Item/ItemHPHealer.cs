using UnityEngine;

public class ItemHPHealer : Item
{
	LifeCounter _life = null;
	AudioSource _item_se;

	void Start ( ) {
		_item_se = GameObject.Find( "Item_SE" ).GetComponent<AudioSource>( );
		_life = GameObject.Find( "LifeCounter" ).GetComponent<LifeCounter>( );
	}

	void OnDestroy ( ) {
		if ( _item_se ) {
			_item_se.PlayOneShot( _item_se.clip );
		}
		_life.addLife( );
	}
}
