using BL.Cashier.DomainObjects;
using BL.Cashier.Interface;
using DAL.Cashier.Interface;
using Entities.Validation;
using System;
using System.Collections.Generic;
using TicketsMemberDAO = DAL.Cashier.DataAccesObjects.TicketsMember;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cashier.Service
{
    public class TicketsServiceC : ITicketsServiceC
    {
        private ITicketsRepositoryC _ticketsRepository;

        public TicketsServiceC(ITicketsRepositoryC ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }

        public bool InsertTicketss(TicketsMember ticketsMember)
        {
            return _ticketsRepository.InsertTickets(new TicketsMemberDAO
            {
                SessionId = ticketsMember.SessionId,
                Row = ticketsMember.Row,
                Seat = ticketsMember.Seat,
                Zone = ticketsMember.Zone,
                Recall = ticketsMember.Recall,
                Booking = ticketsMember.Booking
            });
        }

        public ValidationResult<List<Entities.AdminSingleTable.TableTickets>> SelectTickets()
        {
            return _ticketsRepository.SelectTickets();
        }
    }
}
