using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
//! TODO:MyNameSpace
using CarGame.Core;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed              = 1.0f;
    [SerializeField] private float _frameAddSpeed         = 1.0f;
    [SerializeField] private float _wheelSpeed            = 10f;
    [SerializeField] private Rigidbody _rb                = null;
    [SerializeField] private Transform _bodyTransform     = null;
    [SerializeField] private Transform[] _wheelTransforms = { null };

    [Inject]
    private IInputProvider _input = null;

    [Inject]
    private IPlayerParametor _playerParametor = null;

    private Move _move             = null;
    private Rotation _bodyRotation = null;
    private List<Rotation> _wheelRotations = new List<Rotation>();

    void Start()
    {
        Initialize();

        Observable.EveryUpdate()
            .TakeUntilDestroy(this)
            .Where(energy => _playerParametor.GetEnergy() != 0)
            .Subscribe(_ => {
                _move.Car(_frameAddSpeed);
                _bodyRotation.Car(_input.GetMoveDir());
                Debugger.Log(_playerParametor.GetEnergy());
            });

        Observable.EveryUpdate()
            .Where(lostEnergy => _move.LostEnergyTiming)
            .TakeUntilDestroy(this)
            .Subscribe(count => {
                _playerParametor.SetEnergy(-2);
            });

        Observable.EveryUpdate()
            .TakeUntilDestroy(this)
            .Subscribe(animation => {
                wheelRotation();
            });
    }

    private void Initialize()
    {
        _move = new Move(_rb, _bodyTransform, _maxSpeed);
        _bodyRotation = new Rotation(_bodyTransform);

        foreach (var transform in _wheelTransforms)
        {
            _wheelRotations.Add(new Rotation(transform, _wheelSpeed));
        }
    }

    private void wheelRotation() 
    {
        foreach (var rotation in _wheelRotations)
        {
            rotation.Wheel();
        }
    }

    private void Reset()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
    }
}
