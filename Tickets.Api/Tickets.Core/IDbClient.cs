using MongoDB.Driver;

namespace Tickets.Core
{
    public interface IDbClient
    {
        IMongoCollection<Ticket> GetTicketCollection();
    }
}
