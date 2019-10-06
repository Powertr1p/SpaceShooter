using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 1.5f;
    private int _currentScene = 1;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public IEnumerator LoadGameOverScreen()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadGameOverScreen());
    }

    public void LoadNextLevel()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        if (_currentScene <= SceneManager.sceneCount - 1)
            SceneManager.LoadScene(_currentScene + 1);
        else
            SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(_currentScene);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
