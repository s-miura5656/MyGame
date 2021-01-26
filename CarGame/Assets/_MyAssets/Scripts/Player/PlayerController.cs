using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Rigidbody _rb = null;
    [SerializeField] private Transform _transform = null;

    private IInputProvider _input = null;
    private Move _move = null;

    void Start()
    {
        Initialize();

        //! 移動入力
        Observable.EveryUpdate()
            .TakeUntilDestroy(this)
            .Subscribe(_ => {
                _move.Car(_input.GetMoveDir() * speed);
            });
    }

    private void Initialize()
    {
        _input = new UnityInputProvider();
        _move  = new Move(_rb, _transform);
    }

    private void Reset()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
        _transform = this.gameObject.GetComponent<Transform>();
    }
}
