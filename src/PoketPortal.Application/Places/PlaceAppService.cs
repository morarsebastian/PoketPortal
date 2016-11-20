using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using PoketPortal.Places.Dtos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Device.Location;
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

        public async Task<ListResultDto<PlaceListDto>> GetAll(GetAllPlacesInput input)
        {

            //if (maxDistanceInMeter == 0)
            //{
            //    maxDistanceInMeter = 1000000;
            //}
            //var search = new Search
            //{
            //    Query = new Query(
            //        new Filtered(
            //            new Filter(
            //                new GeoDistanceFilter(
            //                    "detailscoordinates",
            //                    new GeoPoint(centerLongitude, centerLatitude),
            //                    new DistanceUnitMeter(maxDistanceInMeter)
            //                )
            //            )
            //        )
            //        {
            //            Query = new Query(new MatchAllQuery())
            //        }
            //    ),
            //    Sort = new SortHolder(
            //        new List<ISort>
            //        {
            //            new SortGeoDistance("detailscoordinates", DistanceUnitEnum.m, new GeoPoint(centerLongitude, centerLatitude))
            //            {
            //                Order = OrderEnum.asc
            //            }
            //        }
            //    )
            //};

            //List<MapDetail> result;
            //using (var context = new ElasticsearchContext(ConnectionString, new ElasticsearchSerializerConfiguration(_elasticsearchMappingResolver)))
            //{
            //    result = context.Search<MapDetail>(search).PayloadResult.Hits.HitsResult.Select(t => t.Source).ToList();
            //}

            //return result;

            GeoCoordinate a = new GeoCoordinate((double)input.Latitude, (double)input.Longitude);

            var places = await _placeRepository
                .GetAll()
                .OrderByDescending(place => place.CreationTime)
                .ToListAsync();

            var allPlaces = ObjectMapper.Map<List<PlaceListDto>>(places);
            //var results = new List<PlaceListDto>();

            var results = places
                .Where(place => a.GetDistanceTo(new GeoCoordinate((double)place.Latitude, (double)place.Longitude)) <= (double)input.Radius)
                .OrderBy(place => a.GetDistanceTo(new GeoCoordinate((double)place.Latitude, (double)place.Longitude)));

            //foreach (var place in allPlaces)
            //{
            //    if(a.GetDistanceTo(new GeoCoordinate((double)place.Latitude, (double)place.Longitude)) < (double)input.Radius)
            //    {
            //        results.Add(place);
            //    }
            //}

            //results = results.OrderBy(place => a.GetDistanceTo(new GeoCoordinate((double)place.Latitude, (double)place.Longitude)));

            return new ListResultDto<PlaceListDto>(ObjectMapper.Map<List<PlaceListDto>>(results));
        }
    }
}
