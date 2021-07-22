using System;
using Zenject;

public class ProduceUnitCommandCommandCreator : CommandCreatorBase<IProduceUnitCommand>
{    
    [Inject] private AssetsContext _context;
    [Inject] private DiContainer _diContainer;

    protected override void classSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
    {
        IProduceUnitCommand command;
        if (CommandSubType == 0)
        {
            command = new ProduceUnitCommand();
        } else if (CommandSubType == 1)
        {
            command = new GrenadierProduceUnitCommand();
        }
        else
        {
            command = new ProduceUnitCommand();
        }
        var produceUnitCommand = _context.Inject(command);
        _diContainer.Inject(produceUnitCommand);
        creationCallback?.Invoke(produceUnitCommand);
    }
}