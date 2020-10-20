using BL.Admin.DomainObjects;
using Entities.AdminSingleTable;
using Entities.Validation;
using System.Collections.Generic;

namespace BL.Admin.Interface
{
    public interface ITicketsService
    {
        ValidationResult<List<TableTickets>> SelectTickets();
        bool InsertTicketss(TicketsMember ticketsMember);
        bool UpdateTicketss(TicketsMember ticketsMember);
        bool DeleteTicketss(TicketsMember ticketsMember);
    }
}
