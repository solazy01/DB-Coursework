using Entities.AdminSingleTable;
using Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Cleaner
{
    public interface ITimetableRepository
    {
        ValidationResult<List<TableTimetable>> SelectTimetable();
    }
}
