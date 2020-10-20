using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cashier.DomainObjects
{
    public class SessionMember
    {
        public string SessionId { set; get; }
        public string FilmId { set; get; }
        public string HallId { set; get; }
        public string Date { set; get; }
        public string Time { set; get; }
    }
}
