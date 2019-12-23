using FootBall.Domains.Enums;
using FootBall.Infrastructure.Repositories.IRepositories;
using FootBall.Web.Commands.Base;

namespace FootBall.Web.Commands.Players
{
    public class SetPlayerPriorityCommand : ICommand
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly int _vkId;
        private readonly int _priority;

        public SetPlayerPriorityCommand(IPlayerRepository playerRepository, int vkId, int priority)
        {
            _playerRepository = playerRepository;
            _vkId = vkId;
            _priority = priority;
        }
        public ICommandResult Run()
        {
            var player = _playerRepository.GetPlayerByVkId(_vkId);
            player.Priority = _priority;
            player.Status = EPlayerStatus.ReadyToGame;

            _playerRepository.Save(player);

            return new CommandResult
            {
                Success = true
            };
        }
    }
}