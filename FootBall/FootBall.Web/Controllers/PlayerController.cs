using FootBall.Infrastructure.Repositories.IRepositories;
using FootBall.Infrastructure.Translators;
using FootBall.Web.Commands;
using FootBall.Web.Commands.Players;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FootBall.Web.Controllers
{
    [Route("[controller]")]
    public class PlayerController : CommandExecutor
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITranslatorFactory _translatorFactory;

        public PlayerController(ILogger<CommandExecutor> logger, IPlayerRepository playerRepository, ITranslatorFactory translatorFactory) : base(logger)
        {
            _playerRepository = playerRepository;
            _translatorFactory = translatorFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ExecuteData(new GetPlayersCommand(_playerRepository, _translatorFactory));
        }

        [HttpPost]
        [Route("set")]
        public IActionResult SetPriority(int id, int priority)
        {
            return Execute(new SetPlayerPriorityCommand(_playerRepository, id, priority));
        }

        [HttpGet]
        [Route("remove")]
        public IActionResult RemovePlayer(int id)
        {
            return Execute(new RemovePlayerCommand(_playerRepository, id));
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register(int id, string name)
        {
            return Execute(new RegisterPlayerCommand(_playerRepository, id, name));
        }
    }
}