using UnityEngine;

public class Item : MonoBehaviour {
	void OnTriggerEnter2D( Collider2D collision ) {
		if ( collision.tag == "Player" ) {
			Destroy( gameObject );
		}
	}
}
