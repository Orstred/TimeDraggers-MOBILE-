using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;
    GameManager()
    {
        if(GameManager.instance == null)
        instance = this;
    }
    #endregion

    //General
    public Transform PlayerCharacter;
    public Transform MoveToPoint;
    public LayerMask ObstacleLayer;
    public LayerMask BoxLayer;


    //Snaps object to a 1X1 grid
    public void SnapToGrid(Transform transformer)
    {
        if (!unchecked(transformer.position.z == (int)transformer.position.z))
        {
            transformer.position = new Vector3(transformer.position.x, transformer.position.y, Mathf.Round(transformer.position.z));
        }
        if (!unchecked(transformer.position.x == (int)transformer.position.x))
        {
            transformer.position = new Vector3(Mathf.Round(transformer.position.x), transformer.position.y, transformer.position.z);
        }
    }

    //Win the current level
    public void Victory(int nextlevel = 1)
    {

    }
}
