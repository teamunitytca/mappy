using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private bool _isFacingLeft = false;
    [SerializeField]
    private bool _isSpecialDoor = false;

    [SerializeField]
    private GameObject _SubController = null;

    [SerializeField]
    private GameObject _microWave = null;

    private bool _opened = false;

	// Use this for initialization
	void Awake ()
    {
        //this.gameObject.GetComponent<Animator>().SetBool("opened", _opened);

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
	
	public void OpenDoor()
    {
        _opened = true;
        gameObject.SetActive(false);
        Instantiate(_microWave, transform.position, Quaternion.identity, null);
        //this.gameObject.GetComponent<Animator>().SetBool("opened", _opened);
    }

    public override void Use()
    {
        OpenDoor();
    }
}
