using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step : MonoBehaviour {
	private Animator _animator = null;

	void Start () {
		_animator = GetComponent<Animator> ();
	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			_animator.SetTrigger ("trigger");
		}
	}
}
