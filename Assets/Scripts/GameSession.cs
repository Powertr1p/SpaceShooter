using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSession : MonoBehaviour
{
    private int _score = 0;

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _firstMenuScreen;
    [SerializeField] private bool _isPaused;
    [SerializeField] private GameObject _optionsMenu;

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
                _firstMenuScreen.SetActive(true);
                _optionsMenu.SetActive(false);
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
        ResumeGame();
        ResetGame();
        FindObjectOfType<LevelLoader>().LoadStartMenu();
    }

    public void QuitGame()
    {
        FindObjectOfType<LevelLoader>().QuitGame();
    }

    public void OpenOptionsMenu()
    {
        _firstMenuScreen.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void BackToFirstMenu()
    {
        _optionsMenu.SetActive(false);
        _firstMenuScreen.SetActive(true);
    }
}
