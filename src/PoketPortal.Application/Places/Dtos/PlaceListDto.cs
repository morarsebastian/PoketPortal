using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoketPortal.Places.Dtos
{
    public class GetAllPlacesInput
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public decimal Radius { get; set; }
    }

    [AutoMapFrom(typeof(Place))]
    public class PlaceListDto : EntityDto, IHasCreationTime
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string Properties { get; set; }
    }
}
