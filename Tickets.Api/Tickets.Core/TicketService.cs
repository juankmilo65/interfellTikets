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

        public List<Ticket> GetTickets()
        {
            return _tickets.Find(ticket => true).ToList();
        }
    }
}
