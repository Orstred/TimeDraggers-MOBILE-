using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{




    public void GetLevel(int Level)
    {
        SceneManager.LoadScene(Level);
    }
    public void OptionsMenu(Canvas opt)
    {
        opt.enabled = !opt.isActiveAndEnabled;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
