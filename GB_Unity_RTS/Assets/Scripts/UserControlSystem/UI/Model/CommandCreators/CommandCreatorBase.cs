using System;

public abstract class CommandCreatorBase<T> where T : class,ICommand
{
    public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
    {
        CommandSubType = commandExecutor.GetCommandSubType();
        var classSpecificExecutor = commandExecutor as ICommandExecutor<T>;
        if (classSpecificExecutor != null)
        {
            classSpecificCommandCreation(callback);
        }
        return commandExecutor;
    }

    protected abstract void classSpecificCommandCreation(Action<T> creationCallback);

    public virtual void ProcessCancel() { }

    protected int CommandSubType = 0;
}