﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Text _healthText;
    private Player _player;

    private void Start()
    {
        _healthText = GetComponent<Text>();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        _healthText.text = _player.Health.ToString();
    }
}
