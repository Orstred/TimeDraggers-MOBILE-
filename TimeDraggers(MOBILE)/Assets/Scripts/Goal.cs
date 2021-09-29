using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int NextLevel;
    GameManager World;
    private void Start()
    {
        World = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        World.Victory(nextlevel: NextLevel);
    }


}
