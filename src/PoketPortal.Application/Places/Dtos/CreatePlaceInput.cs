using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoketPortal.Places.Dtos
{
    [AutoMap(typeof(Place))]
    public class CreatePlaceInput
    {
        [Required]
        [MaxLength(Place.MaxTitleLength)]
        public string Title { get; set; }

        [MaxLength(Place.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public string Properties { get; set; }
    }
}
