using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputSystemExtension
{
    public static ReadOnlyReactiveProperty<bool> ToUpdateBaseBoolReactiveProperty(this InputAction inputAction)
    {
        return Observable.EveryUpdate().Select(_ => inputAction.IsPressed()).ToReadOnlyReactiveProperty(false);
    }
    public static ReadOnlyReactiveProperty<float> ToUpdateBaseFloatReactiveProperty(this InputAction inputAction)
    {
        return Observable.EveryUpdate().Select(_ => inputAction.ReadValue<float>()).ToReadOnlyReactiveProperty(0);
    }
    public static ReadOnlyReactiveProperty<Vector2> ToUpdateBaseVector2ReactiveProperty(this InputAction inputAction)
    {
        return Observable.EveryUpdate().Select(_ => inputAction.ReadValue<Vector2>()).ToReadOnlyReactiveProperty(Vector2.zero);
    }
}
