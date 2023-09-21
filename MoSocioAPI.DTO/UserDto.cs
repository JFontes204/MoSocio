using InvoicingPlan.Model;
using MoSocioAPI.Model;
using MoSocioAPI.Model.Configuration;
using System.Collections.Generic;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class UserDto
    { 
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public List<Role> Roles { get; set; }
    }
}
