
using MoSocioAPI.Model;
using System.Collections.Generic;

namespace InvoicingPlan.Model
{

    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int  InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public List<Role> Roles { get; set; }
    }
}
