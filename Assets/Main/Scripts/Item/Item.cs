using UnityEngine;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start ( ) {
	}

	// Update is called once per frame
	void Update ( ) {

	}

	void OnTriggerEnter2D ( Collider2D collision ) {
		if ( collision.tag == "Player" ) {
			Destroy( gameObject );
		}
	}
}
