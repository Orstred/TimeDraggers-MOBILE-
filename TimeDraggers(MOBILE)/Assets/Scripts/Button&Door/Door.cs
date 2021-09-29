using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Vector3 MoveTo;
    public float Speed;
   

    Vector3 _startpos;
    Transform _transform;
    private void Start()
    {
        transform.parent = null;
        _transform = transform;
        _startpos = _transform.position;
    }

    public void InteractionEnter() 
    {
    
    }
    public void Interact()
    {
        _transform.position = Vector3.Lerp(transform.localPosition, MoveTo, (Time.deltaTime * Speed) / Vector3.Distance(transform.position, MoveTo));
    }
    public void InteractionExit()
    {
        _transform.position = _startpos;
    }
    private void OnDrawGizmosSelected()
    {
        transform.parent = null;
        if (MoveTo == Vector3.zero)
        {
            MoveTo = transform.position;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, MoveTo);
        Gizmos.DrawWireCube(MoveTo, Vector3.Scale(transform.GetComponent<MeshFilter>().sharedMesh.bounds.size, transform.localScale));
    }
}
