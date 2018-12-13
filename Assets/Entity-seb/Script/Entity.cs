using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour
{
    protected enum MOVING
    {
        LEFT,
        RIGTH,
        IDLE,
        FALLED
    }

    [SerializeField]
    protected float _movementSpeed = 0.01f;
    [SerializeField]
    protected MOVING _state = MOVING.IDLE;
    [SerializeField]
    protected bool _isOnGrond = false;

    // Interal data
    protected Animator _animator;
    protected Rigidbody2D _rigidbody;
    protected Collider2D _collider;

    GameObject _player;

    protected void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _collider = gameObject.GetComponent<Collider2D>();

        _player = GameObject.FindWithTag("Player");
    }

    protected void SetRandomDir()
    {
        if (_isOnGrond)
        {
            switch (UnityEngine.Random.Range(0, 3))
            {
                case 1:
                    _state = MOVING.LEFT;
                    break;
                case 2:
                    _state = MOVING.RIGTH;
                    break;
            }
        }
        else
        {
            _state = MOVING.IDLE;
        }
    }

    protected void SetSpeed(ref float newSpeed)
    {
        _movementSpeed = newSpeed;
    }

    protected void AddSpeed(ref float addedSpeed)
    {
        _movementSpeed += addedSpeed;
    }

}
