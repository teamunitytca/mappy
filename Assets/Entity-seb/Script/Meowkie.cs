using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Meowkie : Entity
{

    void FixedUpdate ()
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

        switch (_state)
        {
            case MOVING.LEFT:
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                _rigidbody.AddForce(new Vector2(-_movementSpeed * 100, 0));
                break;
            case MOVING.RIGTH:
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                _rigidbody.AddForce(new Vector2(_movementSpeed * 100, 0));
                break;
            case MOVING.IDLE:
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
                break;
            case MOVING.FALLED:
                break;
        }

        _animator.SetBool("Falled", _falled);
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x * 100));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FloorArea")
        {
            Physics2D.IgnoreCollision(collision.collider, _collider);
            return;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, _collider);
            return;
        }

        if (collision.gameObject.tag == "Door" && _falled)
        {
            Physics2D.IgnoreCollision(collision.collider, _collider);
            return;
        }

        _isOnGrond = true;
        SetRandomDir();
    }
}
