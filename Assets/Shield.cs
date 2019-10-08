using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Player _playerPosition;
    void Start()
    {
        _playerPosition = FindObjectOfType<Player>();
    }

    
    void Update()
    {
        transform.position = _playerPosition.transform.position;
    }
}
