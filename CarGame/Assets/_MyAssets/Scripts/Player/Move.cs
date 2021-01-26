using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    private Rigidbody _rb = null;
    private Transform _transform = null;

    #region コンストラクタ
    public Move() { }
    public Move(Rigidbody rb, Transform transform) 
    {
        _rb = rb;
        _transform = transform;
    }
    #endregion

    public void Car(Vector3 moveDir) 
    {
        _rb.AddForce(moveDir, ForceMode.Force);
    }
}
