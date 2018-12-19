using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COLLIDER : MonoBehaviour {
	private Animator door = null;
	void Start () {
		door = gameObject.GetComponent<Animator> ();
		//door.SetBool("close",true);
	}
	private void OnCollisionEnter2D(Collision2D col)
	{if (col.gameObject.tag == "Enemy") {
			door.SetBool("close",false);
	}
	
	}
}