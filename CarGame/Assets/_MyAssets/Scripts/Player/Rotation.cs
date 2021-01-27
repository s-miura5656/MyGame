using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation
{
    private Transform _transform = null;
    private float _angle = 0f;

    #region コンストラクタ
    public Rotation() { }
    public Rotation(Transform transform)
    {
        _transform = transform;
    }
    #endregion

    public void Car(Vector3 inputDir) 
    {
        float addAngle = inputDir.x;

        _angle += addAngle;

        _angle = Mathf.Clamp(_angle, -30, 30);

        _transform.rotation = Quaternion.Euler(Vector3.up * _angle);
    }
}
