using System.Threading.Tasks;


public class SetDestinationExecutor : CommandExecutorBase<ISetDestinationCommand>
{
    public override async Task ExecuteSpecificCommand(ISetDestinationCommand command)
    {
        GetComponent<MainBuilding>().Destination = command.Destination;
    }
}