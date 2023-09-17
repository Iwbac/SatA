using UnityEngine;
using UniRx;
using System;

public class BombPresenter : MonoBehaviour
{
    [SerializeField]
    private int initialTime = 10; // 爆発までの初期時間（秒）

    private Bomb bomb;
    private IDisposable timerDisposable;
    private int currentTime;

    private void Start()
    {
        bomb = GetComponent<Bomb>();
        currentTime = initialTime;
        UpdateView();

        bomb.OnClickAsObservable()
            .Subscribe(_ =>
            {
                StartTimer();
            });
    }

    private void StartTimer()
    {
        timerDisposable = Observable
            .Interval(TimeSpan.FromSeconds(1))
            .Take(initialTime)
            .Subscribe(_ =>
            {
                currentTime--;
                UpdateView();

                if (currentTime <= 0)
                {
                    Explode();
                }
            });
    }

    private void UpdateView()
    {
        bomb.SetTimer(currentTime);
    }

    private void Explode()
    {
        var charactersInRadius = bomb.GetPlayersInExplosionRadius(BombModel.ExplosionRadius);

        foreach (var characterObject in charactersInRadius)
        {
            // キャラクターのGameObjectからPresenterを取得
            var characterPresenter = characterObject.GetComponent<PlayerPresenter>();

            // ダメージを与える
            characterPresenter?.TakeDamage(BombModel.Damage);
        }

        // 爆発後、爆弾を非アクティブにするなどの処理も追加できます

        // タイマーの購読を解除
        timerDisposable.Dispose();
    }

}
