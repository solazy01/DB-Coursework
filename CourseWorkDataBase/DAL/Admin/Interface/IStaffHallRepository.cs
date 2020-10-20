using System.Collections.Generic;
using Entities.AdminSingleTable;
using Entities.Validation;
using DAL.Admin.DataAccesObjects;

namespace DAL.Admin.Interface
{
    public interface IStaffHallRepository
    {
        ValidationResult<List<TableStaffHall>> SelectStaffHall();
        bool InsertStaffHall(StaffHallMember staffhallMember);
        bool UpdateStaffHall(StaffHallMember staffhallMember);
        bool DeleteStaffHall(StaffHallMember staffhallMember);
    }
}
