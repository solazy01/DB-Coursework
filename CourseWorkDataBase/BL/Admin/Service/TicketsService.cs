using BL.Admin.DomainObjects;
using BL.Admin.Interface;
using DAL.Admin.Interface;
using Entities.AdminSingleTable;
using Entities.Validation;
using System.Collections.Generic;
using TicketsMemberDAO = DAL.Admin.DataAccesObjects.TicketsMember;
namespace BL.Admin.Service
{
    public class TicketsService :ITicketsService
    {
        private ITicketsRepository _ticketsRepository;

        public TicketsService(ITicketsRepository ticketsRepository)
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


        public bool UpdateTicketss(TicketsMember ticketsMember)
        {
            return _ticketsRepository.UpdateTickets(new TicketsMemberDAO
            {
                SessionId = ticketsMember.SessionId,
                Row = ticketsMember.Row,
                Seat = ticketsMember.Seat,
                Zone = ticketsMember.Zone,
                Recall = ticketsMember.Recall,
                Booking = ticketsMember.Booking,
                TicketId = ticketsMember.TicketId

            });
        }


        public bool DeleteTicketss(TicketsMember ticketsMember)
        {
            return _ticketsRepository.DeleteTickets(new TicketsMemberDAO
            {
                TicketId = ticketsMember.TicketId
            });
        }


        public ValidationResult<List<TableTickets>> SelectTickets()
        {
            return _ticketsRepository.SelectTickets();
        }
    }
}
