using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    [SerializeField] private float _bgScrollSpeed = 0.5f;
    private Material _material;
    private Vector2 _offset;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _offset = new Vector2(0, _bgScrollSpeed);
    }

    void Update()
    {
        _material.mainTextureOffset += _offset * Time.deltaTime;
    }
}
