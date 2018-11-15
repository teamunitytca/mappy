using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField]
    private uint _floorNr;

    private GameObject _player;
    private PlayerTraker _traker;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _traker = _player.GetComponent<PlayerTraker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        if (_floorNr != _traker.GetCurrentFloor())
            _traker.SetCurrentFloor(_floorNr);
    }
}
