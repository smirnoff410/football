using System.Collections.Generic;
using System.Linq;
using FootBall.Domains.Entities;
using FootBall.Domains.Repository.Base;
using FootBall.Web.Commands.Base;

namespace FootBall.Web.Commands.Matches
{
    public class GetMatchPlayersCommand : ICommand<IEnumerable<string>>
    {
        private readonly IRepository<Match> _matchRepository;
        private readonly int _matchId;

        public GetMatchPlayersCommand(IRepository<Match> matchRepository, int matchId)
        {
            _matchRepository = matchRepository;
            _matchId = matchId;
        }
        public ICommandResult<IEnumerable<string>> Run()
        {
            var match = _matchRepository.GetById(_matchId);
            var players = match.Players.Select(c => c.Name);

            return new CommandResult<IEnumerable<string>>
            {
                Success = true,
                Result = players
            };
        }
    }
}