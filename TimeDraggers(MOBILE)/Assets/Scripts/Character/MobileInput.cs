using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{

    #region private instances
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
    public LayerMask IgnoreLayer;

    private void Update()
    {
        RaycastHit hit;



        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f, ~IgnoreLayer))
            {
                if(hit.transform.tag != "Player" && Vector3.Distance(hit.transform.position, MovePoint.position) <= 2)
                {
                    #region MoveTo

                    if (!Physics.CheckSphere(hit.point, .2f, Obstacles))
                    {
                        MoveTo(hit.transform);
                    }

                    #endregion
                }
            }
        }

    }


    void MoveTo(Transform t)
    {
        MovePoint.position = t.position + Vector3.up;
    }




    bool CheckForBoxHorizontal(int SquaresAhead = 1)
    {
        return true;
    }
    bool CheckForBoxVertical(int SquaresAhead = 1)
    {
        return true;
    }







    Vector3 GetDirection(Vector3 RelativePoint)
    {
        Vector3 dir = (_transform.position - RelativePoint).normalized;
        return dir;
    }
}
