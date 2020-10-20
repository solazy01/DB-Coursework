using Entities.AdminSingleTable;
using Entities.Validation;
using System.Collections.Generic;
using DAL.Admin.DataAccesObjects;

namespace DAL.Admin.Interface
{
    public interface IHallRepository
    {
        ValidationResult<List<TableHall>> SelectHall();
        bool InsertHall(HallMember hallMember);
        bool UpdateHall(HallMember hallMember);
        bool DeleteHall(HallMember hallMember);
    }
}
