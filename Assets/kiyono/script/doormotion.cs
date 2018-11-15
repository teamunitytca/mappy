using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doormotion : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionStay2D(Collision2D collision) {

		if (collision.gameObject.tag == "Player") {

			if (Input.GetMouseButtonDown (0)) {

				GameObject prefab = (GameObject)Resources.Load ("kiyono/Resources/microwave");

				GetComponent<Animator> ().SetTrigger("trigger");

					Debug.Log ("(・∀・)ｲｲ!!");
			}
		}
	}

}
