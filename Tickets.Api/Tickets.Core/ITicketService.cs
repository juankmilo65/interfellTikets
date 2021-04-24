using System.Collections.Generic;

namespace Tickets.Core
{
    public interface ITicketService
    {
        List<Ticket> GetTickets();
        Ticket AddTicket(Ticket ticket);
        Ticket GetTicket(string id);
    }
}
