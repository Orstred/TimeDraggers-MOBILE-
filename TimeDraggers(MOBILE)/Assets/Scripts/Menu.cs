using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{

    
    
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("SavedLevel");
        SceneManager.LoadScene(2);
    }
    public void ContinueLevel()
    {


   
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
        
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedLevel"));
      
        }
        else
        {
            SceneManager.LoadScene(1);
        }
      
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
