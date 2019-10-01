using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConfig _waveConfig;
    private List<Transform> _enemyWaypoints;

    private int _waypointIndex = 0;

    private void Start()
    {
        _enemyWaypoints = _waveConfig.GetWaypoints();
        transform.position = _enemyWaypoints[_waypointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig _waveConfig)
    {
        this._waveConfig = _waveConfig;
    }

    private void Move()
    {
        if (_waypointIndex <= _enemyWaypoints.Count - 1)
        {
            transform.position = Vector2.MoveTowards(
                                                transform.position,
                                                _enemyWaypoints[_waypointIndex].transform.position,
                                                _waveConfig.GetMoveSpeed() * Time.deltaTime);

            if (transform.position == _enemyWaypoints[_waypointIndex].transform.position)
                _waypointIndex++;
        }
        else
            Destroy(gameObject);
    }
}
