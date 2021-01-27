using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using System; // .NET 4.xモードで動かす場合は必須

public class RxTimeCounter : MonoBehaviour
{
    [SerializeField] private Button button = null;

    //イベントを発行する核となるインスタンス
    private Subject<int> timerSubject = new Subject<int>();

    private Subject<string> kaoSubject = new Subject<string>();

    private CompositeDisposable disposables = new CompositeDisposable();

    private IObservable<Unit> onClickButton => button.onClick.AsObservable();

    //イベントの購読側だけを公開
    public IObservable<int> OnTimeChanged => timerSubject;

    public IObservable<string> kao => kaoSubject;

    void Start()
    {
        onClickButton
            .First()
            .TakeUntilDestroy(this)
            .Subscribe(_ =>
            {
                Observable.FromCoroutine(TimerCoroutine)
                    .Subscribe(__ =>
                    {
                        kaoSubject.OnNext("＼(^o^)／");
                    });
            });


        //onClickButton
        //   .Subscribe(_ =>
        //   {
        //       Observable.FromCoroutine(TimerCoroutine)
        //           .Subscribe(__ =>
        //           {
        //               kaoSubject.OnNext("＼(^o^)／");
        //           });
        //   })
        //   .AddTo(disposables);

        //disposables.Dispose();
    }

    IEnumerator TimerCoroutine()
    {
        var time = 30;

        while (time > 0)
        {
            time--;

            //イベントを発行
            timerSubject.OnNext(time);

            //1秒待つ
            yield return new WaitForSeconds(1);
        }
    }
}