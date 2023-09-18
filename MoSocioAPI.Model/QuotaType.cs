using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoSocioAPI.Model
{
    [Table("QuotaTypes")]
    public class QuotaType
    {
        [Key]
        public int QuotaTypeId { get; set; }
        public string Label { get; set; }
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public Institution Institution { get; set; }
    }
}
