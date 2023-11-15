using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] int buildIndex;

    public void LoadGame()
    {
        SceneManager.LoadScene(buildIndex);
    }
}
