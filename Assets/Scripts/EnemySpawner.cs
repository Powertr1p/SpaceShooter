using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> _waveConfigs;
    [SerializeField] private int _startingWave = 0;
    [SerializeField] private bool _looping = false;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (_looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int _waveIndex = _startingWave; _waveIndex < _waveConfigs.Count; _waveIndex++)
        {
            var _currentWave = _waveConfigs[_waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(_currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig _waveConfigs)
    {
        for (int _enemyCount  = 0; _enemyCount < _waveConfigs.GetNumberOfEnemies(); _enemyCount++)
        { 
            var _newEnemy = Instantiate(
                 _waveConfigs.GetEnemyPrefab(),
                 _waveConfigs.GetWaypoints()[0].transform.position,
                 Quaternion.identity);
            _newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(_waveConfigs);

            yield return new WaitForSeconds(_waveConfigs.GetTimeBetweenSpawns());
        }
    }
}
