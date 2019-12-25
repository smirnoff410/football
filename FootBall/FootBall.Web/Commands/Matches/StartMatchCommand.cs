using FootBall.Contacts.Dto.Match;
using FootBall.Domains.Entities;
using FootBall.Domains.Repository.Base;
using FootBall.Infrastructure.Extensions;
using FootBall.Web.Commands.Base;

namespace FootBall.Web.Commands.Matches
{
    public class StartMatchCommand : ICommand<StartMatchResponseDto>
    {
        private readonly IRepository<Match> _matchRepository;
        private readonly int _playerCount;

        public StartMatchCommand(IRepository<Match> matchRepository, int playerCount)
        {
            _matchRepository = matchRepository;
            _playerCount = playerCount;
        }

        public ICommandResult<StartMatchResponseDto> Run()
        {
            var match = new Match
            {
                PlayersCount = _playerCount
            };

            match.MarkAsNew();
            _matchRepository.Save(match);
            
            return new CommandResult<StartMatchResponseDto>
            {
                Success = true,
                Result = new StartMatchResponseDto
                {
                    MatchId = match.Id
                }
            };
        }
    }
}