using TypeLite;
using MoSocioAPI.Model.Configuration;
using System;
using MoSocioAPI.Model;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class ContactTypeDto
    {
        public int ContactTypeId { get; set; }
        public string Label { get; set; }
    }
}
