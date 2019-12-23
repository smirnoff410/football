namespace FootBall.Web.Commands.Base
{
    public interface ICommand
    {
        ICommandResult Run();
    }

    public interface ICommand<TResult>
    {
        ICommandResult<TResult> Run();
    }
}