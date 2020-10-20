using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cashier.DomainObjects
{
    public class FilmsMember
    {
            
        public string FilmId { set; get; }

        public string Title { set; get; }

        public string Country { set; get; }
        public string Producer { set; get; }

        public string Duration { set; get; }
        public string ReleaseDate { set; get; }
        public string Genre { set; get; }

        public string BasePrice { set; get; }
    }
}

