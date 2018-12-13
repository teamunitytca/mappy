using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anna : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update( ) {
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			Debug.Log ("Hit");
		}

	
		if (Input.GetMouseButtonDown (0)) {
			print ("左ボタンが押されている");
			animator.SetTrigger ("New Trigger");

		}
	}
}