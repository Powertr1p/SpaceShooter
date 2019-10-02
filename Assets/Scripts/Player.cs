using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config params
    [Header("Player")]
    [SerializeField] private float _moveSpeedPerUnit = 10f;
    [SerializeField] private float _padding = 0.49f;
    [SerializeField] private int _health = 200;

    [Header("Projectile")]
    [SerializeField] private GameObject _laserBullet;
    [SerializeField] private float _projectileFiringPeriod = 0.1f;
    [SerializeField] private float _projectileSpeed = 10f;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip _shootingSound;
    [SerializeField] [Range(0, 1)] private float _volumeShootSounds = 0.10f;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] [Range(0, 1)] private float _volumeDeathSound = 0.50f;

    private Coroutine _firingCouroutine;

    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;

    private void Start()
    {
        SetUpBoundaries();
    }

    private void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           _firingCouroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(_firingCouroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        { 
        GameObject laser = Instantiate(
                _laserBullet, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _projectileSpeed);
        AudioSource.PlayClipAtPoint(_shootingSound, Camera.main.transform.position, _volumeShootSounds);
            yield return new WaitForSeconds(_projectileFiringPeriod);
        }
    }

    private void Move()
    {
        float _deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeedPerUnit;
        float _deltaY = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeedPerUnit;

        float _newYPos = Mathf.Clamp(transform.position.y + _deltaY, _yMin, _yMax);
        float _newXPos = Mathf.Clamp(transform.position.x + _deltaX, _xMin, _xMax);

        transform.position = new Vector2(_newXPos, _newYPos);
    }

    private void SetUpBoundaries()
    {
        Camera _gameCamera = Camera.main;
        _xMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _padding;
        _xMax = _gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _padding;

        _yMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _padding;
        _yMax = _gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _padding;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer _damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!_damageDealer) { return; }
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
        AudioSource.PlayClipAtPoint(_deathSound, Camera.main.transform.position, _volumeDeathSound);
        Destroy(gameObject);
    }
}
