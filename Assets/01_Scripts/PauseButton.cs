using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }
}
