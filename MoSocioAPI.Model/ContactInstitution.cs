using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoSocioAPI.Model
{
    [Table("ContactsInstitution")]
    public class ContactInstitution
    {
        [Key]
        public int ContactId { get; set; }
        public string Label { get; set; }
        public int ContactTypeId { get; set; }
        [ForeignKey("ContactTypeId")]
        public ContactType ContactType { get; set; }
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public Institution Institution { get; set; }
    }
}
