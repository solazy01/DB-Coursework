using DAL.Cashier.DataAccesObjects;
using Entities.AdminSingleTable;
using Entities.Validation;
using System.Collections.Generic;

namespace DAL.Cashier.Interface
{
    public interface ITicketsRepositoryC
    {
        ValidationResult<List<TableTickets>> SelectTickets();
        bool InsertTickets(TicketsMember ticketsMember);
    }
}
