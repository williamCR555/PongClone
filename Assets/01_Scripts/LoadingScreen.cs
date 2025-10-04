using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Slider progressBar;
    public float loadTime = 5f;
    private float Timer = 0f;
    private bool IsLoading = true;

    void Start()
    {

    }
    
    void Update()
    {
        LoadGame();
    }
    void LoadGame()
    {
        if (IsLoading)
        {
            Timer += Time.deltaTime;
            if (progressBar != null )
            {
                progressBar.value = Timer / loadTime;
            }

            if (Timer >= loadTime)
            {
                IsLoading = false;
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
