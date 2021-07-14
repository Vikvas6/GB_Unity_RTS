using System;
using UnityEngine;
using Utils;


public abstract class ValueScriptableObject<T> : ScriptableObject, IAwaitable<T>
{
    public class NewValueNotifier<TAwaited> : Awaiter<TAwaited>
    {
        private readonly ValueScriptableObject<TAwaited> _scriptableObjectValueBase;

        public NewValueNotifier(ValueScriptableObject<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += onNewValue;
        }

        private void onNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= onNewValue;
            onEvent(obj);
        }
    }
    
    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;

    public virtual void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }
}
