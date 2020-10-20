using DAL.Admin.DataAccesObjects;
using Entities.AdminSingleTable;
using Entities.Validation;
using System.Collections.Generic;
using Entities.ComboBox;

namespace DAL.Admin.Interface
{
    public interface IStaffRepository
    {
        ValidationResult<List<TableStaff>> SelectStaff();
        bool InsertStaff(StaffMember staffMember);
        bool UpdateStaff(StaffMember staffMember);
        bool DeleteStaff(StaffMember staffMember);
        ValidationResult<List<IDFullNameStaff>> SelectIDFullName();

        ValidationResult<List<RolePosition>> SelectRole();
        ValidationResult<List<RolePosition>> SelectPosition();
    }
}
