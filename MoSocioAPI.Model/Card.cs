using System;

namespace MoSocioAPI.Model
{
    public class Card
    {
 
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public bool IsActived { get; set; }
        public bool WasRaised { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateExpiration { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
