﻿using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using System.Linq;

namespace MoSocioAPI.Shared.Repositories
{
    public interface IPartnerRepository : IRepository
    {
        IQueryable<PartnerDto> GetPartners(PartnerFilter filter);
    }
}
