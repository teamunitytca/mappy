using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION : MonoBehaviour {
	private Rigidbody2D rb;
	private Animator _animator = null;
	[SerializeField] float countdown = 3;
	[SerializeField] float speed=0.01f;
	[SerializeField] int R;
	bool _counter = false;
	bool _dorapo_trigger = false;
	float velocity = 0;
	void Start () {
		_animator = GetComponent<Animator> ();
		velocity = 0;
		R = 0;
	}


	void move( ) {
		if (velocity != 0) {
			_animator.SetBool ("WALK", false);
		} else {
			_animator.SetBool ("WALK", true);
		}
		if (transform.position.x <= -9 - R) {
			countdown -= Time.deltaTime;
			velocity = 0;
			if (countdown <= 0) {
				velocity = speed;
				R = 0;
				R = Random.Range (3, 9);
				countdown = 3;
			}	
	   }
		if (transform.position.x >= 9 - R) {
			countdown -= Time.deltaTime;
			velocity = 0;
			if (countdown <= 0) {
				velocity = -speed;
				R = 0;
				R = Random.Range (-10, -4);
				countdown = 3;
			}
		}

		transform.position += new Vector3 (velocity/10, 0, 0);

	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Door") {
			if (velocity > 0) {
				_animator.SetBool ("WALK", false);
				_animator.SetTrigger ("doortest");
				this.transform.position =
				new Vector3 (
					transform.position.x - 2.5f,
					transform.position.y,
					transform.position.z);
				transform.rotation = Quaternion.Euler (0, 0, 90);
				_counter = true;
			} 
		}
		if (col.gameObject.tag == "Floor") {
			if (this.transform.rotation.z <= 1 && this.transform.rotation.z >= -1) {
				velocity = speed;
			} 
			if (_dorapo_trigger == true) {
				transform.rotation = Quaternion.Euler (0, 0,90);
				_counter = true;
				if (_counter == true) {
					_animator.SetBool ("WALK", true);
				} else {
					_animator.SetBool ("WALK", false);}
			}
		}
		if (col.gameObject.tag == "dorapo") {
			_dorapo_trigger = true;
		}
	}
	void Update () {
		if (_counter == false) {
			move ();
			_animator.SetBool ("door", false);
		} 
		if (_counter == true) {
			velocity = 0;
			countdown -= Time.deltaTime;
			if (countdown <= 0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
				countdown = 3;
				velocity = speed;
				_counter = false;
				_dorapo_trigger = false;
			}

		}
	
	}
	
}