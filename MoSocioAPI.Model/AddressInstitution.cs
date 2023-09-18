using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoSocioAPI.Model
{
    [Table("AddressesInstitution")]
    public class AddressInstitution
    {
        [Key]
        public int AddressId { get; set; }
        public string HomeAddress { get; set; }
        public string Neighborhood { get; set; }
        public string County { get; set; }
        public string province { get; set; }
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public Institution Institution { get; set; }
    }
}
