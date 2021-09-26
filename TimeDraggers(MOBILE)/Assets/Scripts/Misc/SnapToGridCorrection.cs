using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGridCorrection : MonoBehaviour
{
    Transform _transform;
    private void Start()
    {
        _transform = transform;
    }
    private void Update()
    {
        if (!unchecked(_transform.position.z == (int)_transform.position.z))
        {
            _transform.position = new Vector3(_transform.position.x, _transform.position.y, Mathf.Round(_transform.position.z));
        }
        if (!unchecked(_transform.position.x == (int)_transform.position.x))
        {
            _transform.position = new Vector3(Mathf.Round(_transform.position.x), _transform.position.y, _transform.position.z);
        }
    }
}
