using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PoketPortal.Places
{
    [Table("Places")]
    public class Place : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public string Properties { get; set; }

        public Place()
        {
            CreationTime = Clock.Now;
        }

        public Place(string title, string description = null)
            : this()
        {
            Title = title;
            Description = description;
        }

        public Place(string title, string description, decimal latitude, decimal longitude, string properties)
            : this(title, description)
        {
            Latitude = latitude;
            Longitude = longitude;
            Properties = properties;
        }
    }
}
