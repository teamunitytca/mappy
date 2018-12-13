using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    GameObject _currentTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
            _currentTarget = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _currentTarget)
            _currentTarget = null;
    }

    private void Update()
    {
        if (_currentTarget != null && _currentTarget.tag == "Door" && Input.GetButtonDown("Use"))
        {
            _currentTarget.GetComponent<Interactable>().Use(gameObject);
        }
    }
}
