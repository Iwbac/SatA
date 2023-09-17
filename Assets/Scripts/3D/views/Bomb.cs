using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class Bomb : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI buttonText;

    public IObservable<Unit> OnClickAsObservable()
    {
        return button.OnClickAsObservable();
    }

    public void SetTimer(int secondsRemaining)
    {
        buttonText.text = "Time: " + secondsRemaining.ToString();
    }

    public List<GameObject> GetPlayersInExplosionRadius(float explosionRadius)
    {
        var PlayersInRadius = new List<GameObject>();

        var colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        // 爆発範囲内のキャラクターをリストに追加
        PlayersInRadius.AddRange(colliders.Select(collider => collider.gameObject));
        return PlayersInRadius;
    }
}
