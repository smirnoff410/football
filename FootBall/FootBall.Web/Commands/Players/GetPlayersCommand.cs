using System.Collections.Generic;
using System.Linq;
using FootBall.Contacts.Dto.Player;
using FootBall.Domains.Entities;
using FootBall.Domains.Repository.Base;
using FootBall.Infrastructure.Translators;
using FootBall.Web.Commands.Base;

namespace FootBall.Web.Commands.Players
{
    public class GetPlayersCommand : ICommand<List<PlayerDto>>
    {
        private readonly IRepository<Player> _playerRepository;
        private readonly ITranslatorFactory _translatorFactory;

        public GetPlayersCommand(IRepository<Player> playerRepository, ITranslatorFactory translatorFactory)
        {
            _playerRepository = playerRepository;
            _translatorFactory = translatorFactory;
        }

        public ICommandResult<List<PlayerDto>> Run()
        {
            var players = _playerRepository.List();
            var translator = _translatorFactory.GetTranslator<Player, PlayerDto>();
            var result = players.Select(entity => translator.Translate(entity)).ToList();

            return new CommandResult<List<PlayerDto>>
            {
                Success = true,
                Result = result
            };
        }
    }
}