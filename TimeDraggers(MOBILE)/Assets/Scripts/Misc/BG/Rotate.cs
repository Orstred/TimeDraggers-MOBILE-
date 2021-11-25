using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rotate : MonoBehaviour
{
    RectTransform _transform;
    public float RotateSpeed;
    public float FallSpeed;
    private void Start()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        _transform.Rotate(new Vector3(0, 0, RotateSpeed * Time.deltaTime));
        _transform.position += new Vector3(0, FallSpeed, 0) * Time.deltaTime;
    }


}
