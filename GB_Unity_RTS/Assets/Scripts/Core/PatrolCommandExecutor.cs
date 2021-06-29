using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override void ExecuteSpecificCommand(IPatrolCommand command)
    {
        Debug.Log($"Patrol! From: {command.From} to: {command.To}");
    }
}

