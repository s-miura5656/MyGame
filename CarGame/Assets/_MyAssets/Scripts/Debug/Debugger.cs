using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public static class Debugger
{
    [Conditional("UNITY_EDITOR")]
    public static void Log(object o)
    {
        UnityEngine.Debug.Log(o);
    }
}
