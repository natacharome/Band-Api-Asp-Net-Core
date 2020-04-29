using BandApi.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.ValidationAttributes
{
    public class TitleAndDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var album = (AlbumForCreatingDto)validationContext.ObjectInstance;
            if(album.Title == album.Description)
            {
               return new ValidationResult("The Title and the description need to be different",
                   new[] { "AlbumForCreatingDto" });
            }
            return ValidationResult.Success;
       
        }
    }
}
