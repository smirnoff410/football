using FootBall.Domains.Entities;
using FootBall.Infrastructure.Extensions;
using FootBall.Infrastructure.Repositories.IRepositories;
using FootBall.Web.Commands.Base;

namespace FootBall.Web.Commands.Players
{
    public class RegisterPlayerCommand : ICommand
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly int _vkId;
        private readonly string _name;

        public RegisterPlayerCommand(IPlayerRepository playerRepository, int vkId, string name)
        {
            _playerRepository = playerRepository;
            _vkId = vkId;
            _name = name;
        }

        public ICommandResult Run()
        {
            var player = new Player
            {
                VkId = _vkId,
                Name = _name
            };

            player.MarkAsNew();
            _playerRepository.Save(player);

            return new CommandResult
            {
                Success = true
            };
        }
    }
}