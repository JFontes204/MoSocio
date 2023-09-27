using System.Collections.Generic;

namespace MoSocioAPI.Model
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public List<Institution> Institutions { get; set; } = new List<Institution>();
        public List<Partner> Partners { get; set; } =new List<Partner>();
    }
}
