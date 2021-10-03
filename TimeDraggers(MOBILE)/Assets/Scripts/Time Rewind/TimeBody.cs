using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

    public List<PointInTime> PointsInTime;
    public float RecordTime;

    bool isRewinding = false;
    [HideInInspector]
    public bool isrotating = false;
    PlayerCharacter motor;
    PlayerRotation rotator;
    private void Start()
    {
        motor = GameManager.instance.PlayerCharacter.GetComponent<PlayerCharacter>();
        rotator = GameManager.instance.PlayerCharacter.GetComponent<PlayerRotation>();
    }



    private void Update()
    {
        if (!isrotating)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartRewind();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                StopRewind();
            }
        }



    }


    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    public void Record()
    {
        if (PointsInTime.Count > Mathf.Round(RecordTime / Time.fixedDeltaTime))
        {
            PointsInTime.RemoveAt(PointsInTime.Count - 1);
        }
        PointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }
    public void Rewind()
    {
        if (PointsInTime.Count > 0)
        {
            PointInTime pointintime = PointsInTime[0];
            transform.position = pointintime.position;
            transform.rotation = pointintime.rotation;
            PointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }
    public void StartRewind()
    {
        isRewinding = true;
        motor.enabled = false;
       
        GameManager.instance.MoveToPoint.parent = transform;
        GameManager.instance.MoveToPoint.gameObject.SetActive(false);
    }
    public void StopRewind()
    {
        
        isRewinding = false;
        motor.enabled = true;
        GameManager.instance.MoveToPoint.parent = null;
        GameManager.instance.MoveToPoint.gameObject.SetActive(true);
        GameManager.instance.SnapRotation(GameManager.instance.MoveToPoint, Quaternion.Euler(0,0,0));
        GameManager.instance.SnapToGrid(transform);

    }

}
