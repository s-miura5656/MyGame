using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation
{
    private Transform _transform = null;
    private float _angle = 0f;
    private float _wheelSpeed = 10f;

    #region コンストラクタ
    public Rotation() { }
    public Rotation(Transform transform)
    {
        _transform = transform;
    }

    public Rotation(Transform transform, float wheelSpeed)
    {
        _transform  = transform;
        _wheelSpeed = wheelSpeed;
    }

    #endregion

    public void Car(Vector3 inputDir) 
    {
        float addAngle = inputDir.x;

        _angle += addAngle;

        _angle = Mathf.Clamp(_angle, -20, 20);

        _transform.rotation = Quaternion.Euler(Vector3.up * _angle);
    }

    public void Wheel() 
    {
        _transform.Rotate(Vector3.right * _wheelSpeed);
    }
}
