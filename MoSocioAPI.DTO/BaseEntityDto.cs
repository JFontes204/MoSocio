﻿using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class BaseEntityDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
