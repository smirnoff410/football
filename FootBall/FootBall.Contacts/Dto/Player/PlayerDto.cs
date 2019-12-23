using FootBall.Contacts.Dto.Base;
using FootBall.Domains.Enums;

namespace FootBall.Contacts.Dto.Player
{
    public class PlayerDto : EntityDto
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public EPlayerStatus Status { get; set; }
    }
}