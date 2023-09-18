using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoSocioAPI.Model
{
    [Table("Socios")]
    public class Socio
    {
        [Key]
        public int SocioId { get; set; }
        public string NumeroSocio { get; set; }
        public DateTime DataRegisto { get; set; }
    }
}
