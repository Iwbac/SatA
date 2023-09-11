using System;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDisposable
{
    [SerializeField] private InputActionAsset asset;

    public IReadOnlyReactiveProperty<bool> OnJumpKeyPressed => jump;
    public IReadOnlyReactiveProperty<Vector2> OnMoveKeyInput => move;

    private ReadOnlyReactiveProperty<bool> jump = default;
    private ReadOnlyReactiveProperty<Vector2> move = default;

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
        var jumpAction = asset.FindAction("Jump");
        jump = jumpAction.ToUpdateBaseBoolReactiveProperty();

        var moveAction = asset.FindAction("Move");
        move = moveAction.ToUpdateBaseVector2ReactiveProperty();
    }

    public void Dispose()
    {
        jump?.Dispose();
        move?.Dispose();
    }
}