using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Tickets.Core.Entities;

namespace Tickets.Core.DbConfig
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Ticket> _tickets;
        public DbClient(IOptions<TicketDbConfig> ticketDbConfig)
        {
            var client = new MongoClient(ticketDbConfig.Value.Connection_String);
            var database = client.GetDatabase(ticketDbConfig.Value.Database_Name);
            _tickets = database.GetCollection<Ticket>(ticketDbConfig.Value.Ticket_Collection_Name);
        }

        public IMongoCollection<Ticket> GetTicketCollection()
        {
            return _tickets;
        }
    }
}
