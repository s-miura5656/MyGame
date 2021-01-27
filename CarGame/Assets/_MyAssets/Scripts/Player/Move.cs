using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Core 
{
    public class Move
    {
        private Rigidbody _rb        = null;
        private Transform _transform = null;
        private float _speed         = 0f;
        private float _maxSpeed      = 5f;

        #region コンストラクタ
        public Move() { }
        public Move(Rigidbody rb, Transform transform, float maxSpeed)
        {
            _rb        = rb;
            _transform = transform;
            _maxSpeed  = maxSpeed;
        }
        #endregion

        public void Car(float addSpeed)
        {
            AddSpeed(addSpeed);

            _transform.position += _transform.forward * _speed;
        }

        private void AddSpeed(float acceleration) 
        {
            _speed += acceleration;

            _speed = Mathf.Clamp(_speed, 0, _maxSpeed);
        }
    }
}


