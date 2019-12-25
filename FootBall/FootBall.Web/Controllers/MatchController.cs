using FootBall.Contacts.Dto.Match;
using FootBall.Domains.Entities;
using FootBall.Domains.Repository.Base;
using FootBall.Infrastructure.Repositories.IRepositories;
using FootBall.Web.Commands;
using FootBall.Web.Commands.Matches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FootBall.Web.Controllers
{
    [Route("[controller]")]
    public class MatchController : CommandExecutor
    {
        private readonly IRepository<Match> _matchRepository;
        private readonly IPlayerRepository _playerRepository;

        public MatchController(ILogger<CommandExecutor> logger, IRepository<Match> matchRepository, IPlayerRepository playerRepository) : base(logger)
        {
            _matchRepository = matchRepository;
            _playerRepository = playerRepository;
        }

        [HttpPost]
        [Route("start")]
        public IActionResult StartMatch([FromBody] StartMatchRequestDto data)
        {
            return ExecuteData(new StartMatchCommand(_matchRepository, data.PlayersCount));
        }

        [HttpPost]
        [Route("stop")]
        public IActionResult StopMatch([FromBody] StopMatchRequestDto data)
        {
            return ExecuteData(new StopMatchCommand(_matchRepository, data.MatchId));
        }

        [HttpPost]
        [Route("addplayertomatch")]
        public IActionResult AddPlayerToMatch([FromBody] AddPlayerToMatchRequestDto data)
        {
            return Execute(new AddPlayerToMatchCommand(_playerRepository, _matchRepository, data.UserVkId, data.MatchId));
        }

        [HttpPost]
        [Route("removeplayerfrommatch")]
        public IActionResult RemovePlayerFromMatch([FromBody] RemovePlayerFromMatchRequestDto data)
        {
            return Execute(new RemovePlayerFromMatchCommand(_playerRepository, _matchRepository, data.UserVkId, data.MatchId));
        }

        [HttpGet]
        [Route("getplayers")]
        public IActionResult GetMatchPlayers(int matchId)
        {
            return ExecuteData(new GetMatchPlayersCommand(_matchRepository, matchId));
        }
    }
}