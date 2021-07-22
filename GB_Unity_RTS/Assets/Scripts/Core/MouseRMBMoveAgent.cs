using UnityEngine;


public class MouseRMBMoveAgent : MonoBehaviour
{
    [SerializeField] private ChomperCommandsQueue _queue;

    public void RMBMove(Vector3 target)
    {
        _queue.Clear();
        _queue.EnqueueCommand(new MoveCommand(target));
    }
}
