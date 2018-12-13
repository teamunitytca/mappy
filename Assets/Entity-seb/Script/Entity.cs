﻿using System.Collections;
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

    [SerializeField]
    protected bool _falled = false;
    [SerializeField]
    private uint _fallTime = 100;

    private uint _currentFallTime = 100;
    private float _lastSpeed = 1000;

    protected void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _collider = gameObject.GetComponent<Collider2D>();

        _player = GameObject.FindWithTag("Player");
    }
    
    protected void CheckFall()
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

    public void SetFalled(bool falled)
    {
        _falled = falled;
    }

    void Falled()
    {
        _falled = true;
        _currentFallTime = _fallTime;
    }

}
