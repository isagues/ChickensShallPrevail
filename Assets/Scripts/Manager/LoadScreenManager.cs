using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class LoadScreenManager : MonoBehaviour
    {
        [SerializeField] private Image  progressBar;
        [SerializeField] private Text   progressValue;
        [SerializeField] private string targetScene = "MainScene";

        private void Start()
        {
            StartCoroutine(LoadAsync());
        }

        private IEnumerator LoadAsync()
        {
            var operation = SceneManager.LoadSceneAsync(targetScene);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                var progress = operation.progress;
                progressBar.fillAmount = progress;
                progressValue.text = $"Cargando... {(int) (progress * 100)} %";

                if(operation.progress >= .9f)
                {
                    progressValue.text = "Presionar espacio para continuar";
                
                    if(Input.GetKeyDown(KeyCode.Space)) operation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}