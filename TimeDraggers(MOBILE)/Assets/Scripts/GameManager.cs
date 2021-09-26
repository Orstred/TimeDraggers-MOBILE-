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

    public Transform PlayerCharacter;
    public Transform MoveToPoint;
    public LayerMask ObstacleLayer;
    public LayerMask BoxLayer;
}
