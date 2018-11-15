using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Meowkie : Entity
{
    
    [SerializeField]
    private bool _falled = false;
    [SerializeField]
    private uint _fallTime = 100;

    private float _lastSpeed = 1000;
    private uint _currentFallTime = 100;

    void FixedUpdate ()
    {
        if (_falled)
        {
            _state = MOVING.FALLED;
            //_rigidbody.drag = 0.001f;

            if (_rigidbody.velocity.x < _lastSpeed * 10)
            {
                //Destroy(gameObject);
            }

            _lastSpeed = _rigidbody.velocity.x;

            if (_currentFallTime == 0)
            {
                _falled = false;
            }
            else
            {
                _currentFallTime--;
            }
        }

        if (Mathf.Abs(_rigidbody.velocity.x) < 0.00001f && Mathf.Abs(_rigidbody.velocity.y) < 0.00001f && !_falled)
        {
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            SetRandomDir();
        }

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
                _rigidbody.velocity = Vector2.zero;
                break;
            case MOVING.FALLED:
                break;
        }

        _animator.SetBool("Falled", _falled);
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x * 100));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, _collider);
            return;
        }

        if (collision.gameObject.tag == "Door")
        {
            Physics2D.IgnoreCollision(collision.collider, _collider);
            return;
        }

        SetRandomDir();
    }

    void Falled()
    {
        _falled = true;
        _currentFallTime = _fallTime;
    }
}
