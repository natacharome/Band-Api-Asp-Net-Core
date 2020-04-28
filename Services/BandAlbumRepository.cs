using BandApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.Services
{
    public class BandAlbumRepository : IBandAlbumRepository
    {
        private readonly BandAlbumContext _context;

        public BandAlbumRepository(BandAlbumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddAlbum(Guid bandId, Album album)
        {
            throw new NotImplementedException();
        }

        public void AddBand(Band band)
        {
            throw new NotImplementedException();
        }

        public bool AlbumExists(Guid albumId)
        {
            throw new NotImplementedException();
        }

        public bool BandExists(Guid bandId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        public void DeleteBand(Band band)
        {
            throw new NotImplementedException();
        }

        public Album GetAlbum(Guid bandId, Guid albumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetAlbums(Guid bandId)
        {
            throw new NotImplementedException();
        }

        public Band GetBand(Guid bandId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> GetBands()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        public void UpdateBand(Band band)
        {
            throw new NotImplementedException();
        }
    }
}
