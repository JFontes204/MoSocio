using System.Collections.Generic;

namespace MoSocioAPI.Model
{

    public class InstitutionType
    {
        public int InstitutionTypeId { get; set; }
        public string Label { get; set; }
        public List<Institution> Institutions { get; set; }
    }
}
