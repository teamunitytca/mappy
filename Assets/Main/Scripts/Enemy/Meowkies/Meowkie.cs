using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meowkie : MonoBehaviour
{
	enum MOVE_STATE{
		LEFT,
		RIGTH,
		IDLE,
        JUMPING
	}

	Rigidbody2D _rig;
	Animator _ani;
    GameObject _player;
    Collider2D _coll;

    [SerializeField]
	float _speed = 0;
	[SerializeField]
	MOVE_STATE _moveState = MOVE_STATE.IDLE;

    bool _landed = false;

    void Awake()
    {
        _rig = gameObject.GetComponent<Rigidbody2D>();
        _ani = gameObject.GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _coll = gameObject.GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _landed = true;

        if (other.gameObject.tag == gameObject.tag)
        {
            Physics2D.IgnoreCollision(other.collider, _coll);
            return;
        }
        RandomDir();
    }

    void FixedUpdate()
    {
        #region
        /* if (Mathf.Round(_player.transform.position.x * 100) / 100 == Mathf.Round(gameObject.transform.position.x * 100) / 100)
         {
             _moveState = MOVE_STATE.IDLE;
         }
         else if (_player.transform.position.x > gameObject.transform.position.x)
         {
             _moveState = MOVE_STATE.RIGTH;
         }
         else if (_player.transform.position.x < gameObject.transform.position.x)
         {
             _moveState = MOVE_STATE.LEFT;
         }*/
        #endregion

        if (_rig.velocity.x == 0 && _rig.velocity.y == 0 && _landed)
            RandomDir();

        switch (_moveState)
        {
            case MOVE_STATE.RIGTH:
                TranslateMove(_speed);
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
                break;
            case MOVE_STATE.LEFT:
                TranslateMove(-_speed);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
                break;
            case MOVE_STATE.IDLE:
                _rig.velocity = new Vector2(0, _rig.velocity.y);
                break;
        }

		_ani.SetFloat ("Speed", Mathf.Abs(_speed));
	}

    void RandomDir()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        switch (Random.Range(1, 3))
        {
            case 0:
                _moveState = MOVE_STATE.IDLE;
                break;
            case 1:
                _moveState = MOVE_STATE.LEFT;
                break;
            case 2:
                _moveState = MOVE_STATE.RIGTH;
                break;
        }
    }

    private void TranslateMove(float x)
    {
        TranslateMove(new Vector3(x, 0, 0));
    }

    private void TranslateMove(Vector3 dir)
	{
		if (Mathf.Abs(_rig.velocity.x) < _speed)
			_rig.AddForce(dir);
	}
}
