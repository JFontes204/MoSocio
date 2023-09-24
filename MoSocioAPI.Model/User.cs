using MoSocioAPI.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingPlan.Model
{

    public class User
    {

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "é Obrigatorio inserir o Nome Completo")]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="é Obrigatorio inserir o e-mail")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "é Obrigatorio informar o UserName")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "é Obrigatorio informar a Password")]
        public string Password { get; set; }

        public int  InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public List<Role> Roles { get; set; }
    }
}
