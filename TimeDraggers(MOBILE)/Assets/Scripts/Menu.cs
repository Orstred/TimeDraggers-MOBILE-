using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NaughtyAttributes;
public class Menu : MonoBehaviour
{

    public bool isMainMenu;
    [ShowIf("isMainMenu")]
    public Slider Music;
    [ShowIf("isMainMenu")]
    public Slider SFX;


    private void Start()
    {
        Music.onValueChanged.AddListener(delegate { UpdateAudio(); });
        SFX.onValueChanged.AddListener(delegate { UpdateAudio(); });
    }


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
    public void UpdateAudio()
    {
        if(isMainMenu)
        {
            AudioManager.instance.MusicVolume = Music.value;
            AudioManager.instance.SfxVolume = SFX.value;
        }
    }
}
