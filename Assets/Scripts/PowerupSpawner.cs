using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _powerUp;
    [SerializeField] private int _spawnChance = 100;

    private int ChoosePowerUp()
    {
        return Random.Range(0, _powerUp.Length);
    }

    public void SpawnPowerUp(Vector3 enemyDiedPosition)
    {
        int chance = Random.Range(0, 101);
        Debug.Log("Chance is: " + chance);
        if (chance <= _spawnChance)
        { 
           GameObject powerUp = Instantiate(_powerUp[ChoosePowerUp()], enemyDiedPosition, Quaternion.identity) as GameObject;
            Debug.Log("SPAWNED");
        }
    }
}
