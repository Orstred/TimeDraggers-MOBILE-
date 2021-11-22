using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{

    #region private instances
    GameManager World;
    Transform MovePoint;
    PlayerCharacter player;
    LayerMask ObstaclesLayer;
    LayerMask BoxLayer;
    Transform _transform;
    float TileSize;
    private void Start()
    {
        World = GameManager.instance;
        MovePoint = World.MoveToPoint;
        player = World.PlayerCharacter.GetComponent<PlayerCharacter>();
        ObstaclesLayer = World.ObstacleLayer;
        _transform = player.transform;
        TileSize = World.TileSize;
        BoxLayer = World.BoxLayer;
    }
    #endregion
    public LayerMask IgnoreLayer;

    private void Update()
    {
        RaycastHit hit;

        if(Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);


            if (Physics.Raycast(ray, out hit, 1000f, ~IgnoreLayer))
            {
                if (hit.transform.tag != "Player" && Vector3.Distance(hit.transform.position, MovePoint.position) <= 10)
                {
                    #region MoveTo
                    if (GetDirection(hit.transform).x == 1 || GetDirection(hit.transform).x == -1 || GetDirection(hit.transform).z == 1 || GetDirection(hit.transform).z == -1)
                    {

                        if (!Physics.CheckSphere(hit.point, .2f, ObstaclesLayer) && !CheckForObst(0, hit.transform))
                        {
                            MoveTo(hit.transform);
                        }

                    }


                    #endregion

                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f, ~IgnoreLayer))
            {
                if(hit.transform.tag != "Player" && Vector3.Distance(hit.transform.position, MovePoint.position) <= 10)
                {
                    #region MoveTo
                    if(GetDirection(hit.transform).x == 1 || GetDirection(hit.transform).x == -1 || GetDirection(hit.transform).z == 1 || GetDirection(hit.transform).z == -1)
                    {

                        if (!Physics.CheckSphere(hit.point, .2f, ObstaclesLayer) && !CheckForObst(0,hit.transform))
                        {
                            MoveTo(hit.transform);
                        }

                    }


                    #endregion
                   
                }
            }
        }

    }


    void MoveTo(Transform t)
    {
   
        MovePoint.position = CheckForBoxAlongTheWay(MovePoint.position, CheckForObstAlongTheWay(MovePoint.position, t.position + Vector3.up));
    }





    bool CheckForObst(int SquaresAhead, Transform t)
    {

        if(Physics.CheckSphere((_transform.position + GetDirection(t)) * SquaresAhead , .2f, ObstaclesLayer))
        {
            return true;
        }

        return false;
    }
   
    Vector3 CheckForObstAlongTheWay(Vector3 pos1, Vector3 pos2)
    {

        Vector3 po1 = pos1;
        Vector3 po2 = pos2;
        Vector3 dir = -(pos1 - pos2).normalized;

        while(po1 != po2)
        {
            if (Physics.CheckSphere(po1, .2f, ObstaclesLayer))
            {
                return po1 - dir.normalized;
            }
            po1 += dir.normalized;     
        }

        return pos2;
    }

    Vector3 CheckForBoxAlongTheWay(Vector3 pos1, Vector3 pos2)
    {
        Vector3 po1 = pos1;
        Vector3 po2 = pos2;
        Vector3 dir = (pos2 - pos1).normalized;
        int squarestostop = 0;


        //Check the squares between the final position and the starting one for boxes
        while (po1 != po2)
        {
            po1 += dir.normalized;
            if (Physics.CheckSphere(po1, .2f, BoxLayer))
            {
                squarestostop++;
                Debug.Log("Found box");
            }
        }

        //Check the square in front of the end position to see if there is a box or obstacle in front
        //If there is a box check the quare in front of it and repeat until there is nothing or there is an obstacle
        if (Physics.CheckSphere(pos2 + dir.normalized, .2f, BoxLayer) && !Physics.CheckSphere(pos2 + dir.normalized, .2f, ObstaclesLayer))
        {
            Debug.LogWarning("Special box condition [CUSTOM_ERROR]");
        }

         //Return the final position based on the squarestostop
         if (squarestostop != 0)  
        {
            return po1 - (dir.normalized * squarestostop);
        }



        return po1;
    }

    Vector3 GetDirection(Transform RelativePoint)
    {
        Vector3 dir = (_transform.position - (RelativePoint.position + Vector3.up)).normalized;
        return dir.normalized;
    }
}
