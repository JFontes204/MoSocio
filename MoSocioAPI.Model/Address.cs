using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoSocioAPI.Model
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string HomeAddress { get; set; }
        public string Neighborhood { get; set; }
        public string County { get; set; }
        public string province { get; set; }
        public int PartnerId { get; set; }
        [ForeignKey("PartnerId")]
        public Partner Partner { get; set; }
    }
}
