using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRoof : MonoBehaviour
{

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Entity>().SetState(Entity.MOVING.IDLE);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Entity>().SetState(Entity.MOVING.IDLE);
        }
    }
}
