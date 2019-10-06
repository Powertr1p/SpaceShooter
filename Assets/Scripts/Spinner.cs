using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1.2f;

    void Update()
    {
        transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }
}
