using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRoof : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Entity>().SetState(Entity.MOVING.IDLE);
    }
}
