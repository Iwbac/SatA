using System;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDisposable
{
    [SerializeField] private InputActionAsset asset;
    public IReadOnlyReactiveProperty<Vector2> OnMoveMouse => mouse;
    public IReadOnlyReactiveProperty<Vector2> OnMove => move;
    public IReadOnlyReactiveProperty<bool> OnJump => jump;
    public IReadOnlyReactiveProperty<bool> OnAttack => attack;
    public IReadOnlyReactiveProperty<bool> OnSkillInvocation => skillInvocation;
    public IReadOnlyReactiveProperty<bool> OnUltimateAttack => ultimateAttack;
    public IReadOnlyReactiveProperty<bool> OnPickUpItem => pickUpItem;

    private ReadOnlyReactiveProperty<Vector2> mouse = default;
    private ReadOnlyReactiveProperty<Vector2> move = default;
    private ReadOnlyReactiveProperty<bool> jump = default;
    private ReadOnlyReactiveProperty<bool> attack = default;
    private ReadOnlyReactiveProperty<bool> skillInvocation = default;
    private ReadOnlyReactiveProperty<bool> ultimateAttack = default;
    private ReadOnlyReactiveProperty<bool> pickUpItem = default;

    private void OnEnable()
    {
        asset.Enable();
    }
    private void OnDisable()
    {
        asset.Disable();
    }
    private void Awake()
    {
        var mouseAction = asset.FindAction("MoveMouse");
        mouse = mouseAction.ToUpdateBaseVector2ReactiveProperty();
        var moveAction = asset.FindAction("Move");
        move = moveAction.ToUpdateBaseVector2ReactiveProperty();
        var jumpAction = asset.FindAction("Jump");
        jump = jumpAction.ToUpdateBaseBoolReactiveProperty();
        var attackAction = asset.FindAction("Attack");
        attack = attackAction.ToUpdateBaseBoolReactiveProperty();
        var skillInvocationAction = asset.FindAction("SkillInvocation");
        skillInvocation = skillInvocationAction.ToUpdateBaseBoolReactiveProperty();
        var ultimateAttackAction = asset.FindAction("UltimateAttack");
        ultimateAttack = ultimateAttackAction.ToUpdateBaseBoolReactiveProperty();
        var pickUpItemAction = asset.FindAction("PickUpItem");
        pickUpItem = pickUpItemAction.ToUpdateBaseBoolReactiveProperty();
    }

    public void Dispose()
    {
        mouse?.Dispose();
        move?.Dispose();
        jump?.Dispose();
        attack?.Dispose();
        skillInvocation?.Dispose();
        ultimateAttack?.Dispose();
        pickUpItem?.Dispose();
    }
}