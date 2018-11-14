using UnityEngine;

public class Trampoline : MonoBehaviour {
	int _Trampoline_HP = 3;

	// Use this for initialization
	void Start ( ) {

	}

	// Update is called once per frame
	void Update ( ) {

	}

	void OnCollisionEnter2D ( Collision2D collision ) {
		if ( gameObject.tag == "Player" ) {
			_Trampoline_HP--;
		}
	}

	public void resetTrampolineHP ( ) {
		_Trampoline_HP = 3;
	}
}
