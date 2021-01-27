using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
//! TODO:MyNameSpace
using CarGame.Value;

public class SceneManager : MonoBehaviour
{
    private Subject<SceneState> _sceneState_s = new Subject<SceneState>();

    void Start()
    {
        
    }
}
