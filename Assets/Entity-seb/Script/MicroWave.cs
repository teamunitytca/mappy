using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroWave : MonoBehaviour
{
    public bool _isFacingLeft = true;
    [SerializeField]
    private bool _hitWall = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
            _hitWall = true;

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Meowkie>().enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !_hitWall)
        {
            collision.gameObject.transform.position = new Vector3(
                (collision.transform.position.x + transform.position.x) * 0.5f, 
                collision.transform.position.y, 
                collision.transform.position.z
                );
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Meowkie>().enabled = true;
        }
    }

    void FixedUpdate ()
    {
		if (_isFacingLeft)
        {
            this.gameObject.transform.position += new Vector3(-.01f, 0, 0);
            this.gameObject.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            this.gameObject.transform.position += new Vector3(.01f, 0, 0);
            this.gameObject.transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
	}
}
