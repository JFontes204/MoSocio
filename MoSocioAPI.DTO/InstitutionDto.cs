using MoSocioAPI.Model;
using MoSocioAPI.Model.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class InstitutionDto
    {
        public int InstitutionId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório preencher o campo nome.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório preencher o campo telefone1."), Phone(ErrorMessage = "Campo Telefone1 só adimite números.")]
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string WhatsApp { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo E-mail é obrigatório."), EmailAddress(ErrorMessage = "Campo E-mail está mal formado.")]
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public int InstitutionTypeId { get; set; }
        public InstitutionType InstitutionType { get; set; }
        public List<Partner> Partners { get; set; }
        public List<Card> Cards { get; set; }
        public List<Quota> Quotas { get; set; }
    }
}
