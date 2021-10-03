using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    //Audio Settings
    [HideInInspector]
    public float MusicVolume;
    [HideInInspector]
    public float SFXVolume;
    Quaternion sec;


    private void Awake()
    {
        SaveCurrentLevel();

        if (MoveToPoint == null)
        {
            MoveToPoint = new GameObject().transform;
            MoveToPoint.gameObject.AddComponent<SnapToGridCorrection>();
        }
    }




   
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

    #region  Snaps objects rotation to a factor of 90
    public void SnapRotation(Transform _transform,Quaternion secondary)
    {
        /*
        if ( Quaternion.Angle(_transform.rotation,secondary) < 45 && Quaternion.Angle(_transform.rotation, secondary) > 0)
        {

            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Quaternion.Angle(_transform.rotation, secondary) > 45 && Quaternion.Angle(_transform.rotation, secondary) > 0)
        {

            _transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Quaternion.Angle(_transform.rotation, secondary) > -45 && Quaternion.Angle(_transform.rotation, secondary) < 0)
        {

            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Quaternion.Angle(_transform.rotation, secondary) < -45 && Quaternion.Angle(_transform.rotation, secondary) < 0)
        {

            _transform.rotation = Quaternion.Euler(0, -90, 0);
        }   

        */
        _transform.rotation = snapToNearestRightAngle(_transform.rotation);

    }
    Quaternion snapToNearestRightAngle(Quaternion currentRotation)
    {
        Vector3 closestToForward = closestToAxis(currentRotation, Vector3.forward);
        Vector3 closestToUp = closestToAxis(currentRotation, Vector3.up);
        return Quaternion.LookRotation(closestToForward, closestToUp);
    }
    Vector3 closestToAxis(Quaternion currentRotation, Vector3 axis)
    {
        Vector3[] checkAxes = new Vector3[] { Vector3.forward, Vector3.right, Vector3.up, -Vector3.forward, -Vector3.right, -Vector3.up };
        Vector3 closestToAxis = Vector3.forward;
        float highestDot = -1;
        foreach (Vector3 checkAxis in checkAxes)
            check(ref highestDot, ref closestToAxis, currentRotation, axis, checkAxis);
        return closestToAxis;
    }
    void check(ref float highestDot, ref Vector3 closest, Quaternion currentRotation, Vector3 axis, Vector3 checkDir)
    {
        float dot = Vector3.Dot(currentRotation * axis, checkDir);
        if (dot > highestDot)
        {
            highestDot = dot;
            closest = checkDir;
        }
    }
    #endregion

    
    public void SaveCurrentLevel()
    {
        if (!PlayerPrefs.HasKey("SavedLevel") || PlayerPrefs.HasKey("SavedLevel") && PlayerPrefs.GetInt("SavedLevel") != SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("SavedLevel", SceneManager.GetActiveScene().buildIndex);
        }
        PlayerPrefs.Save();
    }

    

}
