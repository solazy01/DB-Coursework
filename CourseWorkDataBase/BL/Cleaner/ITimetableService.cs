using Entities.AdminSingleTable;
using Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cleaner
{
    public interface ITimetableService
    {
        ValidationResult<List<TableTimetable>> SelectTimetable();
    }
}
