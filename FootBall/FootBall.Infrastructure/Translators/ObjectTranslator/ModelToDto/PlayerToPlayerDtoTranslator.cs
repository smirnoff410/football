using System;
using AutoMapper;
using FootBall.Contacts.Dto.Player;
using FootBall.Domains.Entities;

namespace FootBall.Infrastructure.Translators.ObjectTranslator.ModelToDto
{
    public class PlayerToPlayerDtoTranslator : Translator<Player, PlayerDto>
    {
        public PlayerToPlayerDtoTranslator(Lazy<IMapper> mapper, IProfileExpression expression) : base(mapper, expression)
        {
        }

        public override void Configure()
        {
            Mapping
                .ForMember(c => c.Name, k => k.MapFrom(c => c.Name))
                .ForMember(c => c.Priority, k => k.MapFrom(c => c.Priority))
                .ForMember(c => c.Status, k => k.MapFrom(c => c.Status));
        }
    }
}