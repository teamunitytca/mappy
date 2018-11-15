using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION : MonoBehaviour {
	private Rigidbody2D rb;
	private Animator _animator = null;
	public float countdown = 3;
	public float speed;
	public int R;
	float velocity = 0;
	void Start () {
		_animator = GetComponent<Animator> ();
		velocity = speed;
		R = 0;
	}


	void Update () {
		if (velocity != 0) {
			_animator.SetBool ("WALK", true);
		}else{
			_animator.SetBool ("WALK", false);
		}
		if (transform.position.x <= -9-R) {
			countdown -= Time.deltaTime;
			velocity = 0;
			if (countdown <= 0) {
				velocity = speed;
				R = 0;
				R = Random.Range (1, 9);
				countdown = 3;
			}
		}

		if (transform.position.x >= 9-R) {
			countdown -= Time.deltaTime;
			velocity = 0;
			if (countdown <= 0) {
				velocity = -speed;
				R = 0;
				R = Random.Range (-9, -1);
				countdown = 3;
			}
		}

		transform.position += new Vector3 (velocity ,0, 0);

	}
}
