using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraTracker : MonoBehaviour
{
    [SerializeField]
    private float _posZ;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        cam.transform.position = new Vector3(0, 0, _posZ) + (Vector3)((Vector2)this.gameObject.transform.position);  
    }
}
