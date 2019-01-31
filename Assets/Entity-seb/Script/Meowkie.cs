using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meowkie : Entity
{

    void FixedUpdate()
    {
        if ( (int)(_lastPos.x * 100)  == (int)(transform.position.x * 100) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f && !_falled)
        {
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            SetRandomDir();
        }

        CheckFall();
        Move();

        _animator.SetBool("Falled", _falled);
        _animator.SetFloat("Speed", Mathf.Abs(_lastPos.x - transform.position.x));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int rng = UnityEngine.Random.Range(0, 3);

        if (collision.tag == "FloorJumpColider")
        {
            if (rng == 0 && collision.GetComponent<JumpOffPoints>().left && collision.GetComponent<JumpOffPoints>().rigth) 
                SetRandomDir();
            else if (rng == 0)
            {
                if (collision.GetComponent<JumpOffPoints>().left)
                    _state = MOVING.LEFT;
                if (collision.GetComponent<JumpOffPoints>().rigth)
                    _state = MOVING.RIGTH;
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
