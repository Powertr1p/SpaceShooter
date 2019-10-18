using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoyAnim : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    public void DamageAnim()
    {
        _animator.SetTrigger("getDamage");
    }
}
