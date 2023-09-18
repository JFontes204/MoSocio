using MoSocioAPI.Model;
using MoSocioAPI.Model.Configuration;
using System;
using TypeLite;

namespace MoSocioAPI.DTO.filters
{
    [TsClass(Module = Constants.TsModule)]
    public class CardFilter : PageInfoDto
    {
        public int? CardId { get; set; }
        public string CardNumber { get; set; }
        public bool IsActived { get; set; }
        public bool WasRaised { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateExpiration { get; set; }
        public Partner Partner { get; set; }
        public Institution Institution { get; set; }
        public bool All { get; set; }
    }
}
