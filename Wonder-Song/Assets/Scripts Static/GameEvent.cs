using System;

public class GameEvent
{
    private event Action _action = delegate { };

    public void Publish()
    {
        _action?.Invoke();
    }

    public void AddSubscriber(Action subscriber)
    {
        _action += subscriber;
    }

    public void RemoveSubscriber(Action subscriber)
    {
        _action -= subscriber;
    }
}

public class GameEvent<T>
{
    private event Action<T> _action = delegate { };

    public void Publish(T param)
    {
        _action?.Invoke(param);
    }

    public void AddSubscriber(Action<T> subscriber)
    {
        _action += subscriber;
    }

    public void RemoveSubscriber(Action<T> subscriber)
    {
        _action -= subscriber;
    }
}
