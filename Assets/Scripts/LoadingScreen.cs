using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] int buildIndex;

    [SerializeField] Slider loadingBar;
    [SerializeField] Canvas canvas;

    public void LoadGame()
    {
        StartCoroutine(AnimateLoadingScreen());

        DontDestroyOnLoad(gameObject);
    }

    IEnumerator AnimateLoadingScreen()
    {
        canvas.enabled = true;

        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(buildIndex);

        while (!loadingOperation.isDone)
        {
            loadingBar.value = loadingOperation.progress / 0.9f;
            yield return null;
        }

        canvas.enabled = false;
    }
}
