using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoSocioAPI.Model
{
    [Table("Cards")]
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public bool IsActived { get; set; }
        public bool WasRaised { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateExpiration { get; set; }
        public int PartnerId { get; set; }
        [ForeignKey("PartnerId")]
        public Partner Partner { get; set; }
        public int InstitutionId { get; set; }
        [ForeignKey("InstitutionId")]
        public Institution Institution { get; set; }
    }
}
