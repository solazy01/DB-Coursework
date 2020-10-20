using System.Collections.Generic;
using Entities.AdminSingleTable;
using Entities.Validation;
using BL.Admin.DomainObjects;

namespace BL.Admin.Interface
{
    public interface IHallService
    {
        ValidationResult<List<TableHall>> SelectHall();
        bool InsertHalls(HallMember hallMember);
        bool UpdateHalls(HallMember hallMember);
        bool DeleteHalls(HallMember hallMember);
    }
}
