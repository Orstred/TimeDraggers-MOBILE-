using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggBoxes : MonoBehaviour
{
    public Vector3 SelectionSize;

    Vector3 draggcenter;



    private void Update()
    {
        #region inputlogic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnterDraggMode();
        }
        if (Input.GetKey(KeyCode.Space))
        {

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ExitDraggMode();
        }
        #endregion

    }

    public void EnterDraggMode()
    {
        Collider[] hitColliders = Physics.OverlapBox(draggcenter + transform.position, SelectionSize, Quaternion.identity);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "BoxHasWeight")
            {

                hitColliders[i].GetComponent<Rigidbody>().isKinematic = true;
                hitColliders[i].transform.parent = transform;
            }
            i++;
        }
    }
    public void ExitDraggMode()
    {
        Box[] lit;
        lit = GetComponentsInChildren<Box>();

        foreach (Box b in lit)
        {

            b.transform.parent = null;
            b.transform.GetComponent<Rigidbody>().isKinematic = false;
            GameManager.instance.SnapToGrid(b.transform);
            GameManager.instance.SnapRotation(b.transform,Quaternion.Euler(0,0,0));
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(draggcenter + transform.position, SelectionSize * 2);
    }
}
