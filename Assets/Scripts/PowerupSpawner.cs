using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] GameObject _powerUp;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void ChoosePowerUp()
    {

    }

    public void SpawnPowerUp(Vector3 enemyDiedPosition)
    {
        int chance = Random.Range(0, 101);
        if (chance <= 5)
        { 
           GameObject powerUp = Instantiate(_powerUp, enemyDiedPosition, Quaternion.identity) as GameObject;
        }
    }
}
