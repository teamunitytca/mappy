using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step : MonoBehaviour {
	private Animator _animator = null;
	bool _counter = false;
	[SerializeField] float countdown = 3;
	void Start () {
		_animator = GetComponent<Animator> ();
	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			_animator.SetBool ("return", true);
			_animator.SetTrigger ("GG");
			_counter = true;
		}
	}
	void Update(){
		if (_counter == true) {
			countdown -= Time.deltaTime;
			if (countdown <= 0) {
				_counter = false;
				countdown = 3;
				_animator.SetBool ("return", false);
			}
		}
	
	}
}
