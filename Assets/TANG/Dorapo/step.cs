using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step : MonoBehaviour {
	
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			Destroy( this.gameObject );
		}
	}
}
