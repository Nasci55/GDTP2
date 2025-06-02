using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    void Start()
    {
        pauseMenu.SetActive(false);

        if (pauseMenu == null)
        {
            return;
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
