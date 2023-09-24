using InvoicingPlan.Model;
using System.Collections.Generic;

namespace MoSocioAPI.Model
{

    public class Institution
    {
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public int InstitutionTypeId { get; set; }
        public InstitutionType InstitutionType { get; set; }
        public List<User> Users { get; set; }
    }
}
