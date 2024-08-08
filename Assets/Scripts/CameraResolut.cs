using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolut : MonoBehaviour
{
    private float _defult;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _defult = _camera.orthographicSize * _camera.aspect;  
    }

    private void Update()
    {
        _camera.orthographicSize = _defult * _camera.aspect;
    }
}
