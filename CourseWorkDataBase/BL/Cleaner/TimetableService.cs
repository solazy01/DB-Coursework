using DAL.Cleaner;
using Entities.AdminSingleTable;
using Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cleaner
{
    public class TimetableService:ITimetableService
    {
        private ITimetableRepository _timetableRepository;

        public  TimetableService (ITimetableRepository timetableRepository)
        {
            _timetableRepository = timetableRepository;
        }
        public ValidationResult<List<TableTimetable>> SelectTimetable()
        {
            return _timetableRepository.SelectTimetable();
        }
    }
}
