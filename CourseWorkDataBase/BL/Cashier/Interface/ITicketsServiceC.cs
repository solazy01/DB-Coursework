using BL.Cashier.DomainObjects;
using Entities.AdminSingleTable;
using Entities.Validation;
using System.Collections.Generic;

namespace BL.Cashier.Interface
{
    public interface ITicketsServiceC
    {
        ValidationResult<List<TableTickets>> SelectTickets();
        bool InsertTicketss(TicketsMember ticketsMember);
    }
}
