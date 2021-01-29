using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CarGame.Core 
{
    public class Move
    {
        private Rigidbody _rb          = null;
        private Transform _transform   = null;
        private float _speed           = 0f;
        private float _maxSpeed        = 5f;
        private Vector3 _oldPos        = Vector3.zero;
        private bool _lostEnergyTiming = false;

        #region コンストラクタ
        public Move() { }
        public Move(Rigidbody rb, Transform transform, float maxSpeed)
        {
            _rb        = rb;
            _transform = transform;
            _maxSpeed  = maxSpeed;
        }
        #endregion

        public bool LostEnergyTiming { get { return _lostEnergyTiming; } }

        public void Car(float addSpeed)
        {
            if (_lostEnergyTiming)
                _lostEnergyTiming = false;

            AddSpeed(addSpeed);

            _transform.position += _transform.forward * _speed;

            var x = Mathf.Clamp(_transform.position.x, -3, 3);

            _transform.position = new Vector3(x, _transform.position.y, _transform.position.z);

            if (_transform.position.z >_oldPos.z + 10)
            {
                _oldPos = _transform.position;
                _lostEnergyTiming = true;
            }
        }

        private void AddSpeed(float acceleration) 
        {
            _speed += acceleration;

            _speed = Mathf.Clamp(_speed, 0, _maxSpeed);
        }
    }
}


