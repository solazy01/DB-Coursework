using DAL.Admin.DataAccesObjects;
using Entities.AdminSingleTable;
using Entities.Validation;
using System.Collections.Generic;

namespace DAL.Admin.Interface
{
    public interface ITicketsRepository
    {
        ValidationResult<List<TableTickets>> SelectTickets();
        bool InsertTickets(TicketsMember ticketsMember);
        bool UpdateTickets(TicketsMember ticketsMember);
        bool DeleteTickets(TicketsMember ticketsMember);
    }
}
