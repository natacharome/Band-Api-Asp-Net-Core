using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.Helpers
{
    public class BandsResourceParameters
    {
        public string MainGenre { get; set; }
        public string SearchQuery { get; set; }

        //Pagination
        const int maxPageSize = 3;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 2;
        public int PageSize 
        { 
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value; 
        }

    }
}
