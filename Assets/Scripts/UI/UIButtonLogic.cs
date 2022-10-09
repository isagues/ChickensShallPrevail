using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonLogic : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevelScene(SoundEffectController soundEffectController) {
        
        soundEffectController.Stop();
        SceneManager.LoadScene("LoadScreen");
    }
    
    public void LoadHelpScene() => Debug.Log("Help scene");
    
    public void LoadSettingsScene() => Debug.Log("Settings scene");

    public void CloseGame() => Application.Quit();
}
