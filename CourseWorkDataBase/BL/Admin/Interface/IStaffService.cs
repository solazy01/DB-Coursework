using System.Collections.Generic;
using Entities.AdminSingleTable;
using Entities.Validation;
using BL.Admin.DomainObjects;
using Entities.ComboBox;

namespace BL.Admin.Interface
{
    public interface IStaffService
    {
        ValidationResult<List<TableStaff>> SelectStaff();
        bool InsertStaffs(StaffMember staffMember);
        bool UpdateStaffs(StaffMember staffMember);
        bool DeleteStaffs(StaffMember staffMember);
        ValidationResult<List<IDFullNameStaff>> SelectStaffID();

        ValidationResult<List<RolePosition>> SelectRole();
        ValidationResult<List<RolePosition>> SelectPosition();
    }
}
