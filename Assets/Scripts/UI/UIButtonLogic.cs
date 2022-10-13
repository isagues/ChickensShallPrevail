using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIButtonLogic : MonoBehaviour
    {
        public void LoadMenuScene()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void LoadLevelScene() { SceneManager.LoadScene("LoadScreen"); }
    
        public void LoadHelpScene() => Debug.Log("Help scene");
    
        public void LoadSettingsScene() => Debug.Log("Settings scene");

        public void CloseGame() => Application.Quit();
    }
}
