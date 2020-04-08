using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEventSO eventToListen;
    public UnityEvent Event;

    private void OnEnable() => eventToListen.Subscribe(this);

    private void OnDisable() => eventToListen.Unsubscribe(this);

    public void Invoke() => Event.Invoke();
}
