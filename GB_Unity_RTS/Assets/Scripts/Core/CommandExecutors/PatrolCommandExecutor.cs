using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;


public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    [SerializeField] private UnitMovementStop _stop;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommandExecutor;
    
    [SerializeField] private NavMeshAgent _agent;
    
    public override async Task ExecuteSpecificCommand(IPatrolCommand command)
    {
        Patrol(command.From, command.To);
    }

    private async void Patrol(Vector3 from, Vector3 to)
    {
        _animator.SetTrigger("Walk");
        var current_destination = to;
        var last_destination = from;
        while (true)
        {
            _agent.SetDestination(current_destination);
            _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
                break;
            }

            var tem_destination = current_destination;
            current_destination = last_destination;
            last_destination = tem_destination;
        }

        _stopCommandExecutor.CancellationTokenSource = null;
        _animator.SetTrigger("Idle");
    }
}

