using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using System;

namespace MoSocioAPI.Shared.Services
{
    public interface ICardService : IDisposable
    {
        ResultCollectionDto<CardDto> GetCards(CardFilter filter);
        ServerResponseDto SaveCard(CardDto cardDto);
        ServerResponseDto DeleteCard(CardDto cardDto);
    }
}
