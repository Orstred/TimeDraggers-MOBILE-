using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{




    public float Speed = 10f;

    GameManager World;
    Transform MovePoint;
    LayerMask Boxlayer;
    LayerMask Obstaclelayer;
    bool _isRotating = false;
    private void Start()
    {
        World = GameManager.instance;
        MovePoint = World.MoveToPoint;
        Boxlayer = World.BoxLayer;
        Obstaclelayer = World.ObstacleLayer;
        MovePoint.parent = null;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, Time.deltaTime * Speed);


        if(Vector3.Distance(transform.position, MovePoint.position) <= 0.5f)
        {
            //Horizontal movement
            if(Input.GetAxisRaw("Horizontal") != 0)
            {

                if (!CheckForObstHorizontal())
                {
                    MoveTowards(x: Input.GetAxisRaw("Horizontal"));
                }

            }

            //Vertical movement
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (!CheckForObstVertical())
                {
                    MoveTowards(z: Input.GetAxisRaw("Vertical"));
                }
            }
        }
    }

    void MoveTowards(float x = 0, float y = 0, float z = 0)
    {
        MovePoint.position += new Vector3(x, y, z);
    }

    public bool CheckForObstVertical(float Squaresahead = 1)
    {
        bool obst = false;
        if (Physics.CheckSphere(MovePoint.position + new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Squaresahead), .2f, Obstaclelayer))
        {
            obst = true;
        }
        return obst;
    }

    public bool CheckForObstHorizontal(float Squaresahead = 1)
    {
        bool obst = false;
        if (Physics.CheckSphere(MovePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * Squaresahead, 0, 0), .2f, Obstaclelayer))
        {
            obst = true;
        }
        return obst;
    }

    public bool CheckForBoxVertical(float Squaresahead = 1)
    {
        bool obst = false;
        if (Physics.CheckSphere(MovePoint.position + new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Squaresahead), .2f, Boxlayer))
        {
            obst = true;
        }
        return obst;
    }

    public bool CheckForBoxHorizontal(float Squaresahead = 1)
    {
        bool obst = false;
        if (Physics.CheckSphere(MovePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * Squaresahead, 0, 0), .2f, Boxlayer))
        {
            obst = true;
        }
        return obst;
    }
}
