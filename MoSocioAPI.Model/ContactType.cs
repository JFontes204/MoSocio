using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoSocioAPI.Model
{
    [Table("ContactTypes")]
    public class ContactType
    {
        [Key]
        public int ContactTypeId{ get; set; }
        public string Label { get; set; }
    }
}
