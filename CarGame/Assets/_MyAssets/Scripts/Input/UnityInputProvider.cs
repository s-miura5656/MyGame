using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInputProvider : IInputProvider
{
    public bool GetDash() { return Input.GetKey(KeyCode.LeftShift); }
    public Vector3 GetMoveDir() { return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized; }
}
