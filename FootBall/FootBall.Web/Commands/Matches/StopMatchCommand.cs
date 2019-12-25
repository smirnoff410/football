using System.Collections.Generic;
using System.Linq;
using FootBall.Contacts.Dto.Match;
using FootBall.Domains.Entities;
using FootBall.Domains.Repository.Base;
using FootBall.Infrastructure.Extensions;
using FootBall.Infrastructure.Models;
using FootBall.Web.Commands.Base;

namespace FootBall.Web.Commands.Matches
{
    public class StopMatchCommand : ICommand<StopMatchResponseDto>
    {
        private readonly IRepository<Match> _matchRepository;
        private readonly int _id;

        public StopMatchCommand(IRepository<Match> matchRepository, int id)
        {
            _matchRepository = matchRepository;
            _id = id;
        }
        public ICommandResult<StopMatchResponseDto> Run()
        {
            var match = _matchRepository.GetById(_id);

            var matchPlayers = new MatchPlayersCalculate();
            var team = matchPlayers.GetTeam(match.Players, match.PlayersCount);

            match.MarkAsDeleted();
            _matchRepository.Save(match);

            return new CommandResult<StopMatchResponseDto>
            {
                Success = true,
                Result = team
            };
        }
    }
}