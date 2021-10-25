using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject _character;

    [SerializeField]
    private float _x_pos;

    [SerializeField]
    private float _y_pos;

    [SerializeField]
    private float _z_pos;

    void Update()
    {
        Vector3 pos = _character.transform.position;
        this.transform.position = new Vector3(pos.x + _x_pos, pos.y + _y_pos, pos.z + _z_pos);
    }
}
