using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nyamco : Entity
{
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody.velocity = new Vector2(0, 3);
        }


        if (Mathf.Abs(_rigidbody.velocity.x) < 0.00001f && Mathf.Abs(_rigidbody.velocity.y) < 0.001f && !_falled)
        {
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            SetRandomDir();
        }

        CheckFall();
        Move();

        _animator.SetBool("Falled", _falled);
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x * 100));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int rng = UnityEngine.Random.Range(0, 3);

        if (collision.tag == "FloorJumpColider")
        {
            if (rng == 0)
                SetRandomDir();
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
