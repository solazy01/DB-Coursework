using System.Collections.Generic;
using Entities.AdminSingleTable;
using Entities.Validation;
using BL.Admin.DomainObjects;


namespace BL.Admin.Interface
{
    public interface IStaffHallService
    {
        ValidationResult<List<TableStaffHall>> SelectStaffHall();
        bool InsertStaffHalls(StaffHallMember staffhallMember);
        bool UpdateStaffHalls(StaffHallMember staffhallMember);
        bool DeleteStaffHalls(StaffHallMember staffhallMember);
    }
}
