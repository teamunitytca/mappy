using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nyamco : Entity
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int rng = UnityEngine.Random.Range(0, 3);

        if (collision.tag == "FloorJumpColider")
        {
            if (rng == 0 && collision.GetComponent<JumpOffPoints>().left && collision.GetComponent<JumpOffPoints>().rigth)
            {
                SetRandomDir();
                _rigidbody.WakeUp();
            }
            else if (rng == 0)
            {
                if (collision.GetComponent<JumpOffPoints>().left)
                    _state = MOVING.LEFT;
                if (collision.GetComponent<JumpOffPoints>().rigth)
                    _state = MOVING.RIGTH;

                _rigidbody.WakeUp();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FloorArea" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Door" && _falled)
        {
            Physics2D.IgnoreCollision(collision.collider, _collider);
            return;
        }

        _isOnGrond = true;
        SetRandomDir();
    }

}
