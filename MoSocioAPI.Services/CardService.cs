using AutoMapper;
using MoSocioAPI.DAC;
using MoSocioAPI.DTO;
using MoSocioAPI.DTO.filters;
using MoSocioAPI.Model;
using MoSocioAPI.Shared;
using MoSocioAPI.Shared.Repositories;
using MoSocioAPI.Shared.Services;
using System;
using System.Linq;

namespace MoSocioAPI.Services
{
    public class CardService : BaseService, ICardService
    {
        private ICardRepository cardRepository;

        public CardService(IUnitOfWork uoW)
            : base(uoW)
        {
            this.cardRepository = this.UoW.Repository<ICardRepository>();
        }
        public ResultCollectionDto<CardDto> GetCards(CardFilter filter)
        {

            IQueryable<CardDto> card = this.cardRepository.GetCards(filter);
            int count = card.Count();
            filter.Records = count;

            return new ResultCollectionDto<CardDto>
            {
                Count = count,
                CurrentPage = filter.CurrentPage,
                PageCount = filter.PageCount,
                RecordsPerPage = filter.RecordsPerPage,
                Data = filter.All ? card.OrderByDescending(c => c.CardId).ToList() : card.OrderByDescending(c => c.CardId).Paginated(filter).ToList()
            };
        }
        public ServerResponseDto SaveCard(CardDto cardDto)
        {
            bool result;

            Card card = Mapper.Map<Card>(cardDto);

            if (card.CardId == 0)
            {
                card.DateCreation = DateTime.Now;
                this.cardRepository.Add(card);
            }
            else
            {
                this.cardRepository.Update(card);
            }
            result = this.UoW.SaveChanges() != 0;

            return new ServerResponseDto
            {
                Id = card.CardId,
                Success = result
            };
        }
        public ServerResponseDto DeleteCard(CardDto cardDto)
        {
            bool result = false;
            int statusId = 2;
            try
            {
                Card card = this.cardRepository.GetById<Card>(cardDto.CardId);
                if (card != null)
                {
                    this.cardRepository.Delete<Card>(card);
                }
                result = this.UoW.SaveChanges() != 0;
                statusId = 1;
            }
            catch (Exception ex)
            {
                statusId = 2;
                Console.WriteLine(ex.Message);
            }

            return new ServerResponseDto
            {
                Success = result,
                StatusId = statusId,
                Message = result ? "Card elimanada com sucesso!" : "Não foi possível eliminar esta Card"
            };
        }
    }
}
