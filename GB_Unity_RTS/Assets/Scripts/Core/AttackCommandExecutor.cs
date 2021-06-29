using UnityEngine;


public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log($"Attack! Target health: {command.Target.Health}");
    }
}
