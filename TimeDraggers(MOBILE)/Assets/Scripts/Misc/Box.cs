using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Transform _transform;
  
    GameManager World;
    private void Start()
    {
        World = GameManager.instance;
        _transform = transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            World.SnapToGrid(_transform);
            World.SnapRotation(_transform, Quaternion.Euler(0,0,0));
        }
    }


}
