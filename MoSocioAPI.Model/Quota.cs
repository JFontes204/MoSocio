using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoSocioAPI.Model
{
    [Table("Quotas")]
    public class Quota
    {
        [Key]
        public int QuotaId { get; set; }
        public string Value { get; set; }
        public DateTime DateCreation { get; set; }
        public int QuotaTypeId { get; set; }
        [ForeignKey("QuotaTypeId")]
        public QuotaType QuotaType { get; set; }
        public int PartnerId { get; set; }
        [ForeignKey("PartnerId")]
        public Partner Partner { get; set; }
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public Institution Institution { get; set; }
    }
}
