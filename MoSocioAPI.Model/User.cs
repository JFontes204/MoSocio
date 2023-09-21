using MoSocioAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingPlan.Model
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="é Obrigatorio inserir o e-mail")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "é Obrigatorio informar o UserName")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "é Obrigatorio informar a Password")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirme a Password")]
        public string ConfirmPassword { get; set; }
        public int  InstitutionId { get; set; }
        [ForeignKey(nameof(InstitutionId))]
        public Institution Institution { get; set; }
        public Role[]  Roles { get; set; }
    }
}
