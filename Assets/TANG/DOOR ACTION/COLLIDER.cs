using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COLLIDER : MonoBehaviour {
	private Animator door = null;
	void Start () {
		door = GetComponent<Animator> ();
	}
	private void OnCollisionEnter2D(Collision2D col)
	{if (col.gameObject.name == "Mappy_OBJ_enemy_0") {
			door.SetBool ("event", false);
		}
	}
}