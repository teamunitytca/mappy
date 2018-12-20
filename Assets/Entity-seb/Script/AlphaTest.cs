using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaTest : MonoBehaviour
{

    [SerializeField]
    private GameObject _player = null;
    [SerializeField]
    private Vector2 _playerPos = new Vector2(0,0);

    [SerializeField]
    Camera _cam = null;

    [SerializeField]
    GameObject[] _postions = null;

    uint _index = 1;

    Vector2 _startPos;

    private void Awake()
    {
        _startPos = new Vector2(_cam.transform.position.x, _cam.transform.position.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_postions.Length >= _index)
            {
                _cam.transform.position = new Vector3(
                    _postions[_index].transform.position.x + _startPos.x,
                    _postions[_index].transform.position.y + _startPos.y,
                    _cam.transform.position.z);

                _player.transform.position = new Vector3(
                    _postions[_index].transform.position.x + _playerPos.x,
                    _postions[_index].transform.position.y + _playerPos.y,
                    0);
            }

            _index++;

            if (_index == _postions.Length)
            {
                _index = (uint)_postions.Length - 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _index--;

            if (0 <= _index)
            {
                _cam.transform.position = new Vector3(
                    _postions[_index].transform.position.x + _startPos.x,
                    _postions[_index].transform.position.y + _startPos.y,
                    _cam.transform.position.z);

                _player.transform.position = new Vector3(
                    _postions[_index].transform.position.x + _playerPos.x,
                    _postions[_index].transform.position.y + _playerPos.y,
                    0);
            }

            if (_index == 0)
            {
                _index = 1;
            }
        }
    }
}
