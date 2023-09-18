using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoSocioAPI.Model
{
    [Table("Provinces")]
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }
        public string Name { get; set; }
    }
}
