﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private float _shotCounter;
    [SerializeField] private float _minTimeBetweenShots = 0.2f;
    [SerializeField] private float _maxTimeBetweenShots = 3.0f;

    [SerializeField] private GameObject _laserBullet;
    [SerializeField] private float _projectileSpeed = 10f;
    [SerializeField] private GameObject _deathVFX;

    private void Start()
    {
        _shotCounter = Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
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
        Destroy(gameObject);
        GameObject _explosion = Instantiate(_deathVFX, transform.position, transform.rotation) as GameObject;
        Destroy(_explosion, 1f);
    }
}
