using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public delegate void ScoreAdd(int score);
    private int _score = 0;

    private void Awake()
    {
        SetUpSingleton();
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
}
