namespace Tools.CQS.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        CommandResult Execute(TCommand command);
    }
}
