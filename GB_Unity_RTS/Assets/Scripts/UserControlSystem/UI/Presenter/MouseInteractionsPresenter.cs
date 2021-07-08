using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;


public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;
    
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Transform _groundTransform;
    
    private Plane _groundPlane;
    
    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);

        var baseStream = Observable.EveryUpdate().Where(_ => !_eventSystem.IsPointerOverGameObject());

        var lmbStream = baseStream.Where(_ => Input.GetMouseButtonUp(0));
        var rmbStream = baseStream.Where(_ => Input.GetMouseButtonUp(1));

        lmbStream.Subscribe(_ => lmbHandler());
        rmbStream.Subscribe(_ => rmbHandler());
    }

    private void lmbHandler()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);
        if (hits.Length == 0)
        {
            return;
        }

        var selectable = SelectHit<ISelectable>(hits);
        if (selectable != null)
        {
            _selectedObject.SetValue(selectable);
        }
    }

    private void rmbHandler()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);
        var attackable = SelectHit<IAttackable>(hits);
        if (attackable != null)
        {
            _attackablesRMB.SetValue(attackable);
        } else if (_groundPlane.Raycast(ray, out var enter))
        {
            _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
        }
    }

    public T SelectHit<T>(RaycastHit[] hits)
    {
        var selected = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .FirstOrDefault(c => c != null);
        return selected;
    }
}
