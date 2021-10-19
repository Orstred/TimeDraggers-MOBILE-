using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGridCorrection : MonoBehaviour
{
    Transform _transform;
    GameManager World;

    private void Start()
    {
        _transform = transform;
        World = GameManager.instance;
        _transform.rotation = World.PlayerCharacter.rotation;
        _transform.position = World.PlayerCharacter.position;
   
    }

    private void Update()
    {
        World.SnapToGrid(_transform);
    }
}
