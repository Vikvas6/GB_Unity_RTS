public interface ICommandExecutor
{
    int GetCommandSubType();
}
public interface ICommandExecutor<T> : ICommandExecutor where T : ICommand
{
}

public interface ICommand {}