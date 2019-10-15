using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exterminatus : MonoBehaviour
{
    private Enemy[] _enemiesOnScene;
    public event UnityAction KillThemAll;

    public void HolyExterminate()
    {
        _enemiesOnScene = FindObjectsOfType<Enemy>();

        foreach (Enemy unit in _enemiesOnScene)
        {
            KillThemAll += unit.MakeDead;
        }
        KillThemAll.Invoke();
    }
}
