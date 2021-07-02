using System;

namespace Utils
{
    public abstract class Awaiter<T> : IAwaiter<T>
    {
        private Action _continuation;
        private bool _isCompleted;
        private T _result;

        protected void onEvent(T obj)
        {
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }
        public bool IsCompleted => _isCompleted;
        public T GetResult() => _result;
    }
}