using FootBall.Domains.Entities;
using FootBall.Domains.Repository.Base;
using FootBall.Infrastructure.Repositories.IRepositories;
using FootBall.Web.Commands.Base;

namespace FootBall.Web.Commands.Matches
{
    public class RemovePlayerFromMatchCommand : ICommand
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IRepository<Match> _matchRepository;
        private readonly int _userVkId;
        private readonly int _matchId;

        public RemovePlayerFromMatchCommand(IPlayerRepository playerRepository, IRepository<Match> matchRepository, int userVkId, int matchId)
        {
            _playerRepository = playerRepository;
            _matchRepository = matchRepository;
            _userVkId = userVkId;
            _matchId = matchId;
        }

        public ICommandResult Run()
        {
            var player = _playerRepository.GetPlayerByVkId(_userVkId);
            var match = _matchRepository.GetById(_matchId);

            match.Players.Remove(player);

            _matchRepository.Save(match);

            return new CommandResult
            {
                Success = true
            };
        }
    }
}