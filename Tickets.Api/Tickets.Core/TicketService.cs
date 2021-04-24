using MongoDB.Driver;
using System.Collections.Generic;

namespace Tickets.Core
{
    public class TicketService : ITicketService
    {
        private readonly IMongoCollection<Ticket> _tickets;
        public TicketService(IDbClient dbClient)
        {
            _tickets = dbClient.GetTicketCollection();
        }

        public Ticket AddTicket(Ticket ticket)
        {
            _tickets.InsertOne(ticket);
            return ticket;
        }

        public Ticket GetTicket(string id)
        {
            return _tickets.Find(book => book.Id == id).First();
        }

        public List<Ticket> GetTickets()
        {
            return _tickets.Find(ticket => true).ToList();
        }
    }
}
