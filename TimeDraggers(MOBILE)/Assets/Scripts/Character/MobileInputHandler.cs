using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputHandler : MonoBehaviour
{
    #region PrivateInstances
    GameManager World;
    Transform MovePoint;
    #endregion

    private void Start()
    {
        World = GameManager.instance;
        MovePoint = World.MoveToPoint;
    }


    private void Update()
    {
        RaycastHit hit;
        if(Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit" + hit.transform.name);
            }

        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit" + hit.transform.name);
            }
        }
    }


}
