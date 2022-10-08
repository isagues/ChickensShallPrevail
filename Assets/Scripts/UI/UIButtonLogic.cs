using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonLogic : MonoBehaviour
{
    public void LoadMenuScene(SoundEffectController soundEffectController)
    {
        soundEffectController.Stop();
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevelScene() => SceneManager.LoadScene("LoadScreen");
    
    public void LoadHelpScene() => Debug.Log("Help scene");
    
    public void LoadSettingsScene() => Debug.Log("Settings scene");

    public void CloseGame() => Application.Quit();
}
