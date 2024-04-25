using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadScene : MonoBehaviour
{
    public float progress;
    public void LoadSceneGame(string sceneName)
    {
        StartCoroutine(SceneStart(sceneName));
    }

    public IEnumerator SceneStart(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;
        while(!asyncOperation.isDone)
        {
            progress = Mathf.Clamp01(asyncOperation.progress/0.9f);
            if (progress == 1)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
