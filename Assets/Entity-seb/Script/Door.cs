using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool _isFacingLeft = false;
    [SerializeField]
    private bool _isSpecialDoor = false;

    [SerializeField]
    private GameObject _SubController = null;

    private bool _opened = false;

	// Use this for initialization
	void Awake ()
    {
        if (_isFacingLeft)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(Mathf.Abs(transform.position.x), transform.position.y, transform.position.z);
        }

        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(-Mathf.Abs(transform.position.x), transform.position.y, transform.position.z);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
