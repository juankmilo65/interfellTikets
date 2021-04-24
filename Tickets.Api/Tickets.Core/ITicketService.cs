using System.Collections.Generic;

namespace Tickets.Core
{
    public interface ITicketService
    {
        List<Ticket> GetTickets();
    }
}
