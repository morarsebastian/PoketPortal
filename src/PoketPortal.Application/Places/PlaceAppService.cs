using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using PoketPortal.Places.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PoketPortal.Places
{
    public class PlaceAppService : PoketPortalAppServiceBase, IPlaceAppService
    {
        private readonly IRepository<Place> _placeRepository;

        public PlaceAppService(IRepository<Place> placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task CreatePlace(CreatePlaceInput input)
        {
            var place = input.MapTo<Place>();

            await _placeRepository.InsertAsync(place);
        }

        public async Task<ListResultDto<PlaceListDto>> GetAll()
        {
            var places = await _placeRepository
                .GetAll()
                //.WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToListAsync();

            return new ListResultDto<PlaceListDto>(
                ObjectMapper.Map<List<PlaceListDto>>(places)
            );
        }
    }
}
