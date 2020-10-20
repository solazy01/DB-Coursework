using System.Collections.Generic;
using BL.Admin.Interface;
using Entities.AdminSingleTable;
using Entities.Validation;
using DAL.Admin.Interface;
using BL.Admin.DomainObjects;
using HallMemberDAO = DAL.Admin.DataAccesObjects.HallMember;

namespace BL.Admin.Service
{
    public class HallService :IHallService
    {
        private IHallRepository _hallRepository;

        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
        }
    



        public bool InsertHalls(HallMember hallMember)
        {
            return _hallRepository.InsertHall(new HallMemberDAO
            {
                Numbers_of_rows = hallMember.Numbers_of_rows,
                Number_of_seats = hallMember.Number_of_seats
            });
        }


        public bool UpdateHalls(HallMember hallMember)
        {
            return _hallRepository.UpdateHall(new HallMemberDAO
            {
                Numbers_of_rows = hallMember.Numbers_of_rows,
                Number_of_seats = hallMember.Number_of_seats,
                HallId = hallMember.HallId

            });
        }


        public bool DeleteHalls(HallMember hallMember)
        {
            return _hallRepository.DeleteHall(new HallMemberDAO
            {
                HallId = hallMember.HallId
            });
        }




        public ValidationResult<List<TableHall>> SelectHall()
        {
            return _hallRepository.SelectHall();
        }
    }
}
