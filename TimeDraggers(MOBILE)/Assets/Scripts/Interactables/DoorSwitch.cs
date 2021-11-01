using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{

    public Door door;



    private void OnTriggerEnter(Collider other)
    {
        door.InteractionEnter();
    }
    private void OnTriggerStay(Collider other)
    {
        door.Interact();
    }
    private void OnTriggerExit(Collider other)
    {
        door.InteractionExit();
    }



}
