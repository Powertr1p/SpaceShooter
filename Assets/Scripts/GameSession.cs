using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public delegate void ScoreAdd(int score);
    private int _score = 0;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private bool _isPaused;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                _isPaused = true;
                _pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    private void SetUpSingleton()
    {
        int _numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (_numberGameSessions > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddToScore(int scoreValue)
    {
        _score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void ResumeGame()
    {
        _isPaused = false;
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMainMenu()
    {
        FindObjectOfType<LevelLoader>().LoadStartMenu();
    }

    public void QuitGame()
    {
        FindObjectOfType<LevelLoader>().QuitGame();
    }
}
