using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoSocioAPI.Model
{
    [Table("Partners")]
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório preencher o campo nome.")]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string PartnerNumber { get; set; }
        public string DocNumber { get; set; }
        public string Photo { get; set; }
        public DateTime DateRegistration { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório preencher o campo telefone principal."), Phone(ErrorMessage = "Campo Telefone1 só adimite números.")]
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province Province { get; set; }
        public int PartnerTypeId { get; set; }
        [ForeignKey("PartnerTypeId")]
        public PartnerType PartnerType { get; set; }
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public Institution Institution { get; set; }
    }
}
