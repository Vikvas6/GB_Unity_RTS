using UnityEngine;


public class SetDestinationCommandCreator : CancellableCommandCreatorBase<ISetDestinationCommand, Vector3>
{
    protected override ISetDestinationCommand createCommand(Vector3 dest) => new SetDestinationCommand(dest);
}
