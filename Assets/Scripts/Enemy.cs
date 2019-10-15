using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityAction MakeDead;

    [Header("Stats Config")]
    [SerializeField] private float _health = 100;
    [SerializeField] private int _scoreValue = 150;
    private float _shotCounter;

    [Header("Shooting params")]
    [SerializeField] private GameObject _laserBullet;
    [SerializeField] private float _projectileSpeed = 10f;
    [SerializeField] private float _minTimeBetweenShots = 0.2f;
    [SerializeField] private float _maxTimeBetweenShots = 3.0f;

    [Header("Sound Effects")]
    [SerializeField] private GameObject _deathVFX;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] [Range(0, 1)] private float _deathSoundVolume = 0.75f;
    [SerializeField] private AudioClip _ShootingSound;
    [SerializeField] [Range(0, 1)] private float _ShootingVolume = 0.50f;
    
    private void Start()
    {
        _shotCounter = Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);
        MakeDead += Die;
    }

    private void Update()
    {
        CountdownAndShoot();
    }

    private void CountdownAndShoot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0f)
        { 
            Fire();
            _shotCounter = Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(_laserBullet, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(_ShootingSound, Camera.main.transform.position, _ShootingVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -_projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer _damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(!_damageDealer) { return; }
        ProcessHit(_damageDealer);
    }

    private void ProcessHit(DamageDealer _damageDealer)
    {
        _health -= _damageDealer.GetDamage();
        _damageDealer.Hit();
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(_scoreValue);
        Destroy(gameObject);
        GameObject _explosion = Instantiate(_deathVFX, transform.position, transform.rotation) as GameObject;
        Destroy(_explosion, 1f);
        AudioSource.PlayClipAtPoint(_deathSound, Camera.main.transform.position, _deathSoundVolume);
        FindObjectOfType<PowerupSpawner>().SpawnPowerUp(transform.position);
    }
}
