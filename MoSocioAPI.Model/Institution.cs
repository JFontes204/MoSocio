using InvoicingPlan.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoSocioAPI.Model
{
    [Table("Institutions")]
    public class Institution
    {
        [Key]
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
        [ForeignKey("ProvinceId")]
        public Province Province { get; set; }
        public int InstitutionTypeId { get; set; }
        [ForeignKey("InstitutionTypeId")]
        public InstitutionType InstitutionType { get; set; }

        //public User[] Users { get; set; }
    }
}
