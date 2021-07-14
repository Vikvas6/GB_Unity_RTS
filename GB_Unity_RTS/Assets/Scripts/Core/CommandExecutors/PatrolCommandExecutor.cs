using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    
    public override async Task ExecuteSpecificCommand(IPatrolCommand command)
    {
        Patrol(command.From, command.To);
    }

    private async void Patrol(Vector3 from, Vector3 to)
    {
        _animator.SetTrigger("Walk");
        while (true)
        {
            await MoveTo(to);
            await MoveTo(from);
        }
    }

    private async Task MoveTo(Vector3 to)
    {
        _agent.SetDestination(to);
        while ((transform.position - to).magnitude >= 0.1f)
        {
            await Task.Yield();
        }
    }
}

