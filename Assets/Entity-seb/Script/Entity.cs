using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour 
{
    public enum MOVING
    {
        LEFT,
        RIGTH,
        IDLE,
        FALLED,
        JUMP,
    }

	public enum ANIM_STATE {
		IDLE,
		MOVE,
		JUMP,
		DIED,
		HIT_DOOR
	}

	[SerializeField]
    protected float _movementSpeed = 0.01f;
    [SerializeField]
    protected float _jumpSpeed = 0.01f;
    [SerializeField]
    protected MOVING _state = MOVING.IDLE;
    [SerializeField]
	protected ANIM_STATE _anim_state;
	[SerializeField]
    protected bool _isOnGrond = false;

    [SerializeField]
    protected bool _falled = false;
    [SerializeField]
    private uint _fallTime = 100;
    [SerializeField]
    protected bool _movable = true;

    // Interal data
    protected Animator _animator;
    protected Rigidbody2D _rigidbody;
    protected Collider2D _collider;

    protected GameObject _player;

    private uint _currentFallTime = 100;

    protected Vector2 _lastPos;

    protected void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _collider = gameObject.GetComponent<Collider2D>();

        _player = GameObject.FindWithTag("Player");
    }

    public void SetState(MOVING stateIn)
    {
        _state = stateIn;
    }
    
    protected void CheckFall()
    {
        if (_falled)
        {
            _state = MOVING.FALLED;

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

    protected void Move()
    {
        _lastPos = transform.position;

        switch (_state)
        {
            case MOVING.LEFT:
                _rigidbody.WakeUp();
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
				transform.position += new Vector3( -_movementSpeed, 0, 0 );
				_anim_state = ANIM_STATE.MOVE;
				break;
            case MOVING.RIGTH:
                _rigidbody.WakeUp();
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
				transform.position += new Vector3( _movementSpeed, 0, 0 );
				_anim_state = ANIM_STATE.MOVE;
                break;
			case MOVING.IDLE:
                _rigidbody.WakeUp();
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
				_anim_state = ANIM_STATE.IDLE;
                break;
			case MOVING.FALLED:
                _rigidbody.WakeUp();
                break;
            case MOVING.JUMP:
                Jump();
				_anim_state = ANIM_STATE.JUMP;
				break;
        }
    }

    public virtual void Jump()
    {
        _rigidbody.Sleep();
        transform.position = new Vector3(transform.position.x, transform.position.y + .02f, 0);
    }

    public void SetFalled(bool falled)
    {
        _falled = falled;
    }

    public void Falled()
    {
        _falled = true;
        _currentFallTime = _fallTime;
    }

}
