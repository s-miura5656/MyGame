using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image gageImage = null;

    private float _oldfillValue = 0f;

    [Inject]
    private IPlayerParametor _playerParametor = null;

    void Start()
    {
        Observable.EveryUpdate()
            .TakeUntilDestroy(this)
            .Subscribe(gage => {
                GageFillControl();
            });
    }

    private void GageFillControl() 
    {
        gageImage.fillAmount = Mathf.Lerp(_oldfillValue, _playerParametor.GetEnergy() * 0.01f, Time.deltaTime * 5);

        _oldfillValue = gageImage.fillAmount;
    }
}
