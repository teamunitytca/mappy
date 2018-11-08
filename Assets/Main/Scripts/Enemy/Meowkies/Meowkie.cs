using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meowkie : MonoBehaviour
{
	enum MOVE_STATE{
		LEFT,
		RIGTH,
		IDLE
	}

	Rigidbody2D _rig;
	Animator _ani;
    GameObject _player;

	[SerializeField]
	float _speed = 0;

	[SerializeField]
	MOVE_STATE _moveState = MOVE_STATE.IDLE;
    void Awake()
    {
        _rig = gameObject.GetComponent<Rigidbody2D>();
        _ani = gameObject.GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Mathf.Round(_player.transform.position.x * 100) / 100 == Mathf.Round(gameObject.transform.position.x * 100) / 100)
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
        }
        


        if (_moveState == MOVE_STATE.RIGTH)
        {
            TranslateMove(new Vector3(_speed, 0, 0));
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
        else if (_moveState == MOVE_STATE.LEFT)
        {
            TranslateMove(new Vector3(-_speed, 0, 0));
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
        else if (_moveState == MOVE_STATE.IDLE)
        {
            _rig.velocity = new Vector2(0, _rig.velocity.y);
        }


		_ani.SetFloat ("Speed", Mathf.Abs(_speed));
	}

	private void TranslateMove(Vector3 dir)
	{
		if (Mathf.Abs(_rig.velocity.x) < _speed)
			_rig.AddForce(dir);
	}
}
