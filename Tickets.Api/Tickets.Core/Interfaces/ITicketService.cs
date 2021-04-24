using System.Collections.Generic;
using Tickets.Core.Entities;

namespace Tickets.Core.Interfaces
{
    public interface ITicketService
    {
        List<Ticket> GetTickets();
        Ticket AddTicket(Ticket ticket);
        Ticket GetTicket(string id);
        void DeleteTicket(string id);
        Ticket UpdateTicket(Ticket ticket);
    }
}
