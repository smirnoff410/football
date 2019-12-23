using System;
using System.Diagnostics;
using FootBall.Web.Commands.Base;
using FootBall.Web.Commands.Base.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FootBall.Web.Commands
{
    public class CommandExecutor : ControllerBase
    {
        private readonly ILogger<CommandExecutor> _logger;

        public CommandExecutor(ILogger<CommandExecutor> logger)
        {
            _logger = logger;
        }

        public IActionResult Execute(ICommand command)
        {
            JsonResult res;
            try
            {
                var time = new Stopwatch();
                time.Start();
                var result = command.Run();
                res = new JsonResult(result)
                {
                    StatusCode = 200
                };

                time.Stop();

                _logger.LogInformation($"Execution time: {time.Elapsed}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while executing the command. Error stack: {ex.Message}");
                var result = new CommandResult
                {
                    Success = false,
                    Error = new Error
                    {
                        Code = 500,
                        Message = ex.Message,
                        Stack = ex.StackTrace
                    }
                };

                res = new JsonResult(result)
                {
                    StatusCode = 500
                };
            }

            return res;
        }

        public IActionResult ExecuteData<TResult>(ICommand<TResult> command)
        {
            JsonResult res;
            try
            {
                var time = new Stopwatch();
                time.Start();
                var result = command.Run();
                res = new JsonResult(result)
                {
                    StatusCode = 200
                };

                time.Stop();

                _logger.LogInformation($"Execution time: {time.Elapsed}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while executing the command. Error stack: {ex.Message}");
                var result = new CommandResult
                {
                    Success = false,
                    Error = new Error
                    {
                        Code = 500,
                        Message = ex.Message,
                        Stack = ex.StackTrace
                    }
                };

                res = new JsonResult(result)
                {
                    StatusCode = 500
                };
            }

            return res;
        }
    }
}