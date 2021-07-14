using System.Threading.Tasks;
using UnityEngine;


public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"Attack! Target health: {command.Target.Health}");
    }
}
