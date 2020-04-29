using BandApi.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.Dtos
{
    // Refers to the class TitleAndDescriptionAttribute in Validation Attributes
    [TitleAndDescription]
    public abstract class AlbumManipulationDto
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(200, ErrorMessage = "Title must be 200 characters maximum")]
        public string Title { get; set; }

        [MaxLength(400, ErrorMessage = "Title must be 200 characters maximum")]
        public virtual string Description { get; set; }
    }
}
