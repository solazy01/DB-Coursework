using BL.Admin.Interface;
using DAL.Admin.Interface;
using System.Collections.Generic;
using Entities.AdminSingleTable;
using Entities.Validation;
using BL.Admin.DomainObjects;
using Entities.ComboBox;
using StaffMemberDAO = DAL.Admin.DataAccesObjects.StaffMember;

namespace BL.Admin.Service
{
    public class StaffService : IStaffService
    {

        
            private IStaffRepository _staffRepository;

            public StaffService(IStaffRepository staffRepository)
            {
                _staffRepository = staffRepository;
            }

        public bool InsertStaffs(StaffMember staffMember)
        {
            return _staffRepository.InsertStaff(new StaffMemberDAO
            {
                FirstName = staffMember.FirstName,
                SecondName= staffMember.SecondName,
                Patronymic = staffMember.Patronymic,
                Position = staffMember.Position,
                BirthDate = staffMember.BirthDate,
                EntryDate = staffMember.EntryDate,
                Login = staffMember.Login,
                Password = staffMember.Password,
                Role = staffMember.Role
            });
        }


        public bool UpdateStaffs(StaffMember staffMember)
        {
            return _staffRepository.UpdateStaff(new StaffMemberDAO
            {
                FirstName = staffMember.FirstName,
                SecondName = staffMember.SecondName,
                Patronymic = staffMember.Patronymic,
                Position = staffMember.Position,
                BirthDate = staffMember.BirthDate,
                EntryDate = staffMember.EntryDate,
                StaffId = staffMember.StaffId,
                Login = staffMember.Login,
                Password = staffMember.Password,
                Role = staffMember.Role
            });
        }


        public bool DeleteStaffs(StaffMember staffMember)
        {
            return _staffRepository.DeleteStaff(new StaffMemberDAO
            {
                Login = staffMember.Login
            });
        }

        public ValidationResult<List<IDFullNameStaff>> SelectStaffID()
        {
            return _staffRepository.SelectIDFullName();
        }


        public ValidationResult<List<TableStaff>> SelectStaff()
            {
                return _staffRepository.SelectStaff();
            }

        public ValidationResult<List<RolePosition>> SelectRole()
        {
            return _staffRepository.SelectRole();
        }

        public ValidationResult<List<RolePosition>> SelectPosition()
        {
            return _staffRepository.SelectPosition();
        }
    }
}
