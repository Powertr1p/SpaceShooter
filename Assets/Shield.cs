using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Player _playerPosition;
    private int _shieldArmor = 200;

    void Start()
    {
        _playerPosition = FindObjectOfType<Player>();
    }

    
    void Update()
    {
        transform.position = _playerPosition.transform.position;
    }

    private void ProccessHit(DamageDealer _damage)
    {
        _shieldArmor -= _damage.GetDamage();
        _damage.Hit();
        if (_shieldArmor <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.GetComponent<DamageDealer>() != null)
            ProccessHit(collision.gameObject.GetComponent<DamageDealer>());
    }
}
