using MongoDB.Driver;
using System.Collections.Generic;
using Tickets.Core.DbConfig;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces;

namespace Tickets.Core.Services
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

        public void DeleteTicket(string id)
        {
            _tickets.DeleteOne(ticket => ticket.Id == id);
        }

        public Ticket GetTicket(string id)
        {
            return _tickets.Find(book => book.Id == id).First();
        }

        public List<Ticket> GetTickets()
        {
            return _tickets.Find(ticket => true).ToList();
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            GetTicket(ticket.Id);
            _tickets.ReplaceOne(t => t.Id == ticket.Id, ticket);
            return ticket;
        }
    }
}
