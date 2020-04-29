using BandApi.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.Dtos
{
    [TitleAndDescriptionAttribute]
    public class AlbumForCreatingDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(400)]

        public string Description { get; set; }
    }
}
