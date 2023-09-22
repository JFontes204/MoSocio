using MoSocioAPI.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingPlan.Model
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "é Obrigatorio inserir o Nome Completo")]
        [MaxLength(80)]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="é Obrigatorio inserir o e-mail")]
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "é Obrigatorio informar o UserName")]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "é Obrigatorio informar a Password")]
        public string Password { get; set; }
        public int  InstitutionId { get; set; }
        [ForeignKey(nameof(InstitutionId))]
        public Institution Institution { get; set; }
        public List<Role> Roles { get; set; }
    }
}
