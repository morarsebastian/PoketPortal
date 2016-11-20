using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PoketPortal.Places.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoketPortal.Places
{
    public interface IPlaceAppService : IApplicationService
    {
        Task<ListResultDto<PlaceListDto>> GetAll(/*GetAllPlacesInput input*/);
        Task CreatePlace(CreatePlaceInput input);
    }
}
