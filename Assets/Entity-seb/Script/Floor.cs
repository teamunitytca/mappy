using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField]
    private uint _floorNr;

    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;

        if (_floorNr != _player.GetComponent<Player>().GetCurrentFloor())
            _player.GetComponent<Player>().SetCurrentFloor(_floorNr);
    }
}
