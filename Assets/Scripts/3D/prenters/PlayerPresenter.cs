using UnityEngine;
using UniRx;

public class PlayerPresenter : MonoBehaviour
{
    private Player player;
    // private PlayerWeapon playerWeapon;
    private PlayerModel playerModel = new();

    public void Start()
    {
        player = GetComponent<Player>();
        player.OnJumpKeyPressed.Skip(1).Subscribe(_ => Jump()).AddTo(this);
        player.OnMoveKeyInput.Skip(1).Subscribe(_ => Move()).AddTo(this);
    }

    private void Jump()
    {
        // 攻撃をここに実装
        Debug.Log("Jump: " + player.OnJumpKeyPressed.Value);
    }

    private void Move()
    {
        // 移動をここに実装
        Debug.Log("Move: " + player.OnMoveKeyInput.Value);
    }
}
