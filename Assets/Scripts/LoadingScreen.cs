using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] int buildIndex;

    [SerializeField] Image loadingBar;
    [SerializeField] Canvas canvas;

    public void LoadGame()
    {
        StartCoroutine(AnimateLoadingScreen());
    }

    IEnumerator AnimateLoadingScreen()
    {
        canvas.enabled = true;

        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(buildIndex);

        while (!loadingOperation.isDone)
        {
            loadingBar.fillAmount = loadingOperation.progress / 0.9f;
            yield return null;
        }

        canvas.enabled = false;
    }
}
