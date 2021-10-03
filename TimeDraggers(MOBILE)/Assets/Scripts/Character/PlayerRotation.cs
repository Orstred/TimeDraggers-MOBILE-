using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerRotation : MonoBehaviour
{

    PlayerCharacter playermotor;
    Transform _transform;
    Transform Movepoint;
    public float RotationSpeed;
    bool isRotating;
    public Canvas RotateArrows;
    GameManager World;
    private void Start()
    {
        World = GameManager.instance;
        playermotor = GetComponent<PlayerCharacter>();
        _transform = transform;
        Movepoint = World.MoveToPoint;
        ExitRotationMode();
    }



    private void Update()
    {
        if(Quaternion.Angle(_transform.rotation, Movepoint.rotation) > 1.5)
        {
            _transform.rotation = Quaternion.Slerp(transform.rotation, Movepoint.rotation, RotationSpeed * Time.deltaTime);
        }
        else
        {
            _transform.rotation = Movepoint.rotation;
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isRotating)
            {
                ExitRotationMode();
            }
            else
            {
                EnterRotationMode();
            }
        }


        if (isRotating && Quaternion.Angle(_transform.rotation, Movepoint.rotation) < 10)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                RotateRight();
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                RotateLeft();
            }
        }
    }

    public void EnterRotationMode()
    {
        playermotor.enabled = false;
        isRotating = true;
        RotateArrows.enabled = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<TimeBody>().isrotating = true;
    }
    public void RotateLeft()
    {
        Movepoint.transform.rotation = Quaternion.Euler(0, Movepoint.rotation.eulerAngles.y + 90, 0);
    }
    public void RotateRight()
    {
        Movepoint.transform.rotation = Quaternion.Euler(0, Movepoint.rotation.eulerAngles.y - 90, 0);
    }
    public void ExitRotationMode()
    {
        playermotor.enabled = true;
        isRotating = false;
        RotateArrows.enabled = false;
        GetComponent<BoxCollider>().enabled = true;
        World.SnapRotation(_transform,Quaternion.Euler(0,0,0));
        GetComponent<TimeBody>().isrotating = false;
    }
}
    