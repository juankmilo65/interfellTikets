using MongoDB.Driver;
using Tickets.Core.Entities;

namespace Tickets.Core.DbConfig
{
    public interface IDbClient
    {
        IMongoCollection<Ticket> GetTicketCollection();
    }
}
