using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    private Exterminatus _killAll;
    private Player _player;
    private float _fallingSpeed; 

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _killAll = GetComponent<Exterminatus>();
        _fallingSpeed = Random.Range(0.07f, 0.2f);
    }

    void Update()
    {
        float newPosY = transform.position.y - _fallingSpeed;
        transform.position = new Vector2(transform.position.x, newPosY);
    }

    public void ActivatePowerUp()
    {
        if (gameObject.tag == "PUShield")
        { 
            GameObject _shieldPowerUp = Instantiate(_shield, _player.transform) as GameObject;
        }
        if (gameObject.tag == "PUKillAll")
        {
            _killAll.HolyExterminate();
        }
    }
}
