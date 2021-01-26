using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInputProvider
{
    bool GetDash();
    Vector3 GetMoveDir();
}
