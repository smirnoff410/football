using FootBall.Web.Commands.Base.Errors;

namespace FootBall.Web.Commands.Base
{
    public interface ICommandResult
    {
        bool Success { get; set; }
        Error Error { get; set; }
    }
    public interface ICommandResult<TResult> : ICommandResult
    {
        TResult Result { get; set; }
    }
}