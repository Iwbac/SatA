using UnityEngine;
using UniRx;

public class PlayerPresenter : MonoBehaviour
{
    private Player player;
    // private PlayerWeapon playerWeapon;

    private void Start()
    {
        player = GetComponent<Player>();
        player.OnMoveMouse.Skip(1).Subscribe(_ => MoveViewpoint()).AddTo(this);
        player.OnMove.Skip(1).Subscribe(_ => Move()).AddTo(this);
        player.OnJump.Skip(1).Subscribe(_ => Jump()).AddTo(this);
        player.OnAttack.Skip(1).Subscribe(_ => Attack()).AddTo(this);
        player.OnSkillInvocation.Skip(1).Subscribe(_ => SkillInvocation()).AddTo(this);
        player.OnUltimateAttack.Skip(1).Subscribe(_ => UltimateAttack()).AddTo(this);
        player.OnPickUpItem.Skip(1).Subscribe(_ => PickUpItem()).AddTo(this);
    }

    public void TakeDamage(int damage)
    {
        var hp = PlayerModel.TakeDamage(damage);
        player.SetHp(hp);
        Debug.Log("TakeDamage: " + PlayerModel.Health);
    }

    private void MoveViewpoint()
    {
        // 視点移動をここに実装
        //Debug.Log("MoveViewpoint: " + player.OnMoveMouse.Value);
    }
    private void Jump()
    {
        // 攻撃をここに実装
        Debug.Log("Jump: " + player.OnJump.Value);
    }
    private void Move()
    {
        // 移動をここに実装
        Debug.Log("Move: " + player.OnMove.Value);
    }
    private void Attack()
    {
        // 攻撃をここに実装
        Debug.Log("Attack: " + player.OnAttack.Value);
    }
    private void SkillInvocation()
    {
        // スキルをここに実装
        Debug.Log("SkillInvocation: " + player.OnSkillInvocation.Value);
    }
    private void UltimateAttack()
    {
        // アルティメット攻撃をここに実装
        Debug.Log("UltimateAttack: " + player.OnUltimateAttack.Value);
    }
    private void PickUpItem()
    {
        // アイテムを拾うをここに実装
        Debug.Log("PickUpItem: " + player.OnPickUpItem.Value);
    }
}
