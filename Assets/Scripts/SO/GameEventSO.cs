using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Game Event", menuName ="Scriptable Object/Game Event")]
public class GameEventSO : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Subscribe(GameEventListener e)
    {
        if (!listeners.Contains(e))
            listeners.Add(e);
    }

    public void Unsubscribe(GameEventListener e)
    {
        if (listeners.Contains(e))
            listeners.Remove(e);
    }

    public void Raise()
    {
        for (int i = listeners.Count - 1; i > -1; i--)
        {
            listeners[i].Invoke();
        }
    }
}
