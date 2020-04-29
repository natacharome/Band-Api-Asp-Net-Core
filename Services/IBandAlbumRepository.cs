using BandApi.Entities;
using BandApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.Services
{
    public interface IBandAlbumRepository
    {
        // Album
        IEnumerable<Album> GetAlbums(Guid bandId);
        Album GetAlbum(Guid bandId, Guid albumId);
        void AddAlbum(Guid bandId, Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(Album album);

        // Band
        IEnumerable<Band> GetBands();
        IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds);
        IEnumerable<Band> GetBands(BandsResourceParameters bandsResourceParameters);
        Band GetBand(Guid bandId);
        void AddBand(Band band);
        void UpdateBand(Band band);
        void DeleteBand(Band band);

        // Both
        bool BandExists(Guid bandId);
        bool AlbumExists(Guid albumId);
        bool Save();
    }
}
