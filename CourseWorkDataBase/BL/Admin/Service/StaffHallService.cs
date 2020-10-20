using System.Collections.Generic;
using BL.Admin.Interface;
using Entities.AdminSingleTable;
using Entities.Validation;
using DAL.Admin.Interface;
using BL.Admin.DomainObjects;
using StaffHallMemberDAO = DAL.Admin.DataAccesObjects.StaffHallMember;

namespace BL.Admin.Service
{
    public class StaffHallService :IStaffHallService
    {
        private IStaffHallRepository _staffhallRepository;

        public StaffHallService(IStaffHallRepository staffhallRepository)
        {
            _staffhallRepository = staffhallRepository;
        }


        public bool InsertStaffHalls(StaffHallMember staffhallMember)
        {
            return _staffhallRepository.InsertStaffHall(new StaffHallMemberDAO
            {
                HallId = staffhallMember.HallId,
                StaffId = staffhallMember.StaffId
            });
        }


        public bool UpdateStaffHalls(StaffHallMember staffhallMember)
        {
            return _staffhallRepository.UpdateStaffHall(new StaffHallMemberDAO
            {
                HallId = staffhallMember.HallId,
                StaffId = staffhallMember.StaffId

            });
        }


        public bool DeleteStaffHalls(StaffHallMember staffhallMember)
        {
            return _staffhallRepository.DeleteStaffHall(new StaffHallMemberDAO
            {
                HallId = staffhallMember.HallId,
                StaffId = staffhallMember.StaffId
            });
        }


        public ValidationResult<List<TableStaffHall>> SelectStaffHall()
        {
            return _staffhallRepository.SelectStaffHall();
        }
    }
}
