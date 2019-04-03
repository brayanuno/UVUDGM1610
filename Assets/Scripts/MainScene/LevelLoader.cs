using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text textPercentage;

    //LoadScene button 
    public void LoadLvel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously (int scenIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenIndex);
        LoadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            textPercentage.text = progress * 100 + "%";
            yield return null;
        }
    }
}
