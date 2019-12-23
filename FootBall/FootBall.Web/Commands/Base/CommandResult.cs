using FootBall.Web.Commands.Base.Errors;

namespace FootBall.Web.Commands.Base
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public Error Error { get; set; }
    }
    public class CommandResult<TResult> : ICommandResult<TResult>
    {
        public bool Success { get; set; }
        public Error Error { get; set; }
        public TResult Result { get; set; }
    }
}