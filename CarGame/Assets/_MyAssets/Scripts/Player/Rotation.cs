using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarGame.Core
{
    public class Rotation
    {
        private Transform _transform = null;
        private float _angle         = 0f;
        private float _lerpEndTime   = 5;
        private float _angleLimit    = 15f;
             
        #region コンストラクタ
        public Rotation() { }
        public Rotation(Transform transform)
        {
            _transform = transform;
        }
        #endregion

        public void Car(Vector3 inputDir)
        {
            if (inputDir.x == 0)
                DirReset();

            float addAngle = inputDir.x;

            _angle += addAngle;

            _angle = Mathf.Clamp(_angle, -_angleLimit, _angleLimit);

            _transform.rotation = Quaternion.Euler(Vector3.up * _angle);
        }

        private void DirReset() 
        {
            if (_angle != 0)
                _angle = Mathf.Lerp(_angle, 0, Time.deltaTime * _lerpEndTime);
        }

    public void Wheel(float wheelSpeed)
        {
            _transform.Rotate(Vector3.right * wheelSpeed);
        }
    }
}