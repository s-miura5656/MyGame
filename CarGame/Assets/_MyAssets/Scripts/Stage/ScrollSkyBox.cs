using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class ScrollSkyBox : MonoBehaviour
{
    [SerializeField] private Material _skybox = null;
    [SerializeField] private float scrollSpeed = 0.001f;
    private float _rotation = 0f;

    void Start()
    {
        Observable.EveryUpdate()
            .TakeUntilDestroy(this)
            .Subscribe(scroll => {
                _skybox.SetFloat("_Rotation", AddRotationValue());
            });
    }

    private float AddRotationValue() 
    {
        if (_rotation < 360)
            _rotation += scrollSpeed;
        else
            _rotation = 0f;

        return _rotation;
    }
}
