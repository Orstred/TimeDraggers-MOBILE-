using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
public class MobileInputHandler : MonoBehaviour
{
    #region PrivateInstances
    GameManager World;
    Transform MovePoint;
    PlayerCharacter player;
    LayerMask Obstacles;
    Transform _transform;
    float TileSize;
    private void Start()
    {
        World = GameManager.instance;
        MovePoint = World.MoveToPoint;
        player = World.PlayerCharacter.GetComponent<PlayerCharacter>();
        Obstacles = World.ObstacleLayer;
        _transform = player.transform;
        TileSize = World.TileSize;
    }
    #endregion



    private void Update()
    {
        RaycastHit hit;
        if(Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {

                if (Vector3.Distance(hit.point, player.transform.position) < TileSize)
                {
                    if (!Physics.CheckSphere(hit.point, .2f, Obstacles))
                    {
                        MoveTowards(hit.transform);
                    }
                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000f, ~LayerMask.GetMask("Box")))
            {
                if (Vector3.Distance(hit.transform.position, player.transform.position) < TileSize)
                {
                   if(hit.transform.tag != "Player")
                        MoveTowards(hit.transform);
                    
                }

            }
        }

    }



    void MoveTowards(Transform t)
    {
       MovePoint.position = t.position + Vector3.up;
    }



    bool CheckForObstVertical(Transform tr, float Squaresahead = 1)
    {
        if (Physics.CheckSphere((MovePoint.position + GetDirection(tr)), .2f, World.ObstacleLayer))
        {
            return true;
        }
        return false;
    }
    bool CheckForObstHorizontal(float Squaresahead = 1)
    {
        if (Physics.CheckSphere(MovePoint.position + new Vector3(Squaresahead, 0, 0), .2f, World.ObstacleLayer))
        {
            return true;
        }
        return false;
    }

    Vector3 GetDirection(Transform t)
    {
        Vector3 dir = new Vector3(0,0,0);
        Vector3 pos = t.position;
        dir = (_transform.position - pos).normalized;

        return -dir;
    }
}
