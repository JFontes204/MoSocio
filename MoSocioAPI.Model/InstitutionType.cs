using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoSocioAPI.Model
{
    [Table("InstitutionTypes")]
    public class InstitutionType
    {
        [Key]
        public int InstitutionTypeId { get; set; }
        public string Label { get; set; }
    }
}
