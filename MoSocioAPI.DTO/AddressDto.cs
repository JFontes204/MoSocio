using TypeLite;
using MoSocioAPI.Model.Configuration;
using System;
using MoSocioAPI.Model;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string HomeAddress { get; set; }
        public string Neighborhood { get; set; }
        public string County { get; set; }
        public string province { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
