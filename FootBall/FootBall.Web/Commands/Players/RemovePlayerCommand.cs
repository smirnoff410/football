using FootBall.Domains.Enums;
using FootBall.Infrastructure.Repositories.IRepositories;
using FootBall.Web.Commands.Base;

namespace FootBall.Web.Commands.Players
{
    public class RemovePlayerCommand : ICommand
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly int _vkId;

        public RemovePlayerCommand(IPlayerRepository playerRepository, int vkId)
        {
            _playerRepository = playerRepository;
            _vkId = vkId;
        }

        public ICommandResult Run()
        {
            var player = _playerRepository.GetPlayerByVkId(_vkId);

            player.Status = EPlayerStatus.Blocked;
            player.Priority = 0;

            _playerRepository.Save(player);

            return new CommandResult
            {
                Success = true
            };
        }
    }
}