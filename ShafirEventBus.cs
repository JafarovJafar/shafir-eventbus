using System;
using System.Collections.Generic;

public class ShafirEventBus
{
    private Dictionary<Type, Delegate> _delegates;

    public ShafirEventBus()
    {
        _delegates = new Dictionary<Type, Delegate>();
    }

    public void Subscribe<T>(Action<T> action)
    {
        if (!_delegates.ContainsKey(typeof(T)))
        {
            _delegates.Add(typeof(T), null);
        }

        var existingDelegate = _delegates[typeof(T)];
        existingDelegate = Delegate.Combine(existingDelegate, action);
        _delegates[typeof(T)] = existingDelegate;
    }

    public void UnSubscribe<T>(Action<T> action)
    {
        if (!_delegates.ContainsKey(typeof(T))) return;

        var existingDelegate = _delegates[typeof(T)];
        existingDelegate = Delegate.Remove(existingDelegate, action);
        _delegates[typeof(T)] = existingDelegate;
    }

    public void Publish<T>(T message)
    {
        if (!_delegates.ContainsKey(typeof(T))) return;

        var existingDelegate = _delegates[typeof(T)];
        var action = (Action<T>)existingDelegate;
        action(message);
    }
}