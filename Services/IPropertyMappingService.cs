using System.Collections.Generic;

namespace BandApi.Services
{
    public interface IPropertyMappingService
    {
        Dictionary<string, PropertyMapingValue> GetPropertyMapping<TSource, TDestination>();
        bool ValidMappingExists<TSource, TDestination>(string fields);
    }
}