using System;
using UnityEngine;
using Zenject;
using UniRx;


public class RMBPresenter : MonoBehaviour
{
    [SerializeField] private Vector3Value _groundClicksRMB;
    
    private ICommandsQueue _queue;
    private bool _isSelected;

    [Inject] private IObservable<ISelectable> _selectedValues;
    
    private void Start()
    {
        _queue = GetComponent<ICommandsQueue>();
        _groundClicksRMB.OnNewValue += MoveTo;
        _selectedValues.Subscribe(OnSelected);
    }

    private void MoveTo(Vector3 target)
    {
        if (!_isSelected) return;
        _queue.Clear();
        _queue.EnqueueCommand(new MoveCommand(target));
    }

    private void OnSelected(ISelectable selected)
    {
        _isSelected = false;
        if (selected != null && gameObject.Equals(((MonoBehaviour) selected).gameObject))
        {
            _isSelected = true;
        }
    }
}
