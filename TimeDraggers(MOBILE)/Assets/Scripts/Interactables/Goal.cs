using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
    public int Level;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            SceneManager.LoadScene(Level);
        }
       
    }


}
