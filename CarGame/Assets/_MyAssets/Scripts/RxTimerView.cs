using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class RxTimerView : MonoBehaviour
{
    //それぞれインスタンスはインスペクタビューから設定

    [SerializeField] private RxTimeCounter timeCounter;
    [SerializeField] private Text counterText; //uGUIのText

    void Start()
    {
        //タイマのカウンタが変化したイベントを受けてuGUI Textを更新する
        timeCounter.OnTimeChanged
            .Subscribe(time =>
            {
                //現在のタイマ値をUIに反映する
                counterText.text = time.ToString();
            })
            .AddTo(this);

        timeCounter.kao
            .TakeUntilDestroy(this)
            .Subscribe(text =>
            {
                counterText.text = text;
            });

        Observable.EveryUpdate()
            .TakeUntilDestroy(this)
            .Where(_ => Input.GetKeyDown(KeyCode.A))
            .Subscribe(_ => {
              Debugger.Log("Aが押されました");
            });
    }
}