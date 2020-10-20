using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AdminSingleTable
{
    public class TableTimetable
    {
        public string Title { private set; get; }

        public string Date { private set; get; }
        public string Time { private set; get; }
        public string HallId { private set; get; }

        public TableTimetable()
        { }

        public TableTimetable(string Title, string Date, string Time, string HallId)
        {
            this.Title = Title;

            this.Date = Date;
            this.Time = Time;
            this.HallId = HallId;
        }
    }
}
