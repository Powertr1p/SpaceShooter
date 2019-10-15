using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
     private Player _player;

    private float _fallingSpeed = 0.1f;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        float newPosY = transform.position.y - _fallingSpeed;
        transform.position = new Vector2(transform.position.x, newPosY);
    }

    public void ActivatePowerUp()
    {
        GameObject _shieldPowerUp = Instantiate(_shield, _player.transform) as GameObject;
    }

}
