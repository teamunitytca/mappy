using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTraker : MonoBehaviour
{
    [SerializeField]
    private uint _currentFloor;
    [SerializeField]
    private uint _prevFloor;

    public void SetCurrentFloor(uint floor)
    {
        _prevFloor = _currentFloor;
        _currentFloor = floor;
    }

    public uint GetCurrentFloor()
    {
        return _currentFloor;
    }

    public uint GetPrevFloor()
    {
        return _prevFloor;
    }
}
