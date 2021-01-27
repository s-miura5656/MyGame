using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
//! TODO:MyNameSpace
using CarGame.Core;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed      = 1.0f;
    [SerializeField] private float _frameAddSpeed = 1.0f;
    [SerializeField] private Rigidbody _rb        = null;
    [SerializeField] private Transform _transform = null;

    private IInputProvider _input = null;
    
    private Move _move         = null;
    private Rotation _rotation = null;

    void Start()
    {
        Initialize();

        Observable.EveryUpdate()
            .TakeUntilDestroy(this)
            .Subscribe(_ => {
                _move.Car(_frameAddSpeed);
                _rotation.Car(_input.GetMoveDir());
                
            });
    }

    private void Initialize()
    {
        _input    = new UnityInputProvider();
        _move     = new Move(_rb, _transform, _maxSpeed);
        _rotation = new Rotation(_transform);
    }

    private void Reset()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
        _transform = this.gameObject.GetComponent<Transform>();
    }
}
