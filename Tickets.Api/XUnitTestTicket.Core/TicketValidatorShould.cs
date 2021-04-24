using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System.Threading.Tasks;
using Tickets.Core;
using Tickets.Core.DbConfig;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces;
using Tickets.Core.Services;
using Xunit;

namespace XUnitTestTicket.Core
{
    public class TicketValidatorShould
    {
        private Mock<IOptions<TicketDbConfig>> _mockOptions;
        private Mock<IMongoDatabase> _mockDB;
        private Mock<IMongoClient> _mockClient;
        private Mock<ITicketService> _ticketService;


        public TicketValidatorShould()
        {
            _mockOptions = new Mock<IOptions<TicketDbConfig>>();
            _mockDB = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();
            _ticketService = new Mock<ITicketService>();
        }

        [Fact]
        public async Task ValidateMongoContextConstructionSuccess()
        {
            _mockOptions.Setup(s => s.Value).Returns(InitTicketConfig());
            _mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.Database_Name, null)).Returns(_mockDB.Object);

            //Act 
            var context = new DbClient(_mockOptions.Object);

            //Assert 
            Assert.NotNull(context);
        }

        [Fact]
        public async Task ValidateCreation()
        {
            //Arrange
            _mockOptions.Setup(s => s.Value).Returns(InitTicketConfig());
            _mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.Database_Name, null)).Returns(_mockDB.Object);


            //Act 
            var context = new DbClient(_mockOptions.Object);
            var myCollection = context.GetTicketCollection();

            var service = new TicketService(context);

          var ticketAdded =   service.AddTicket(new Ticket
            {
                CreationDate = new System.DateTime(),
                UpdateDate = new System.DateTime(),
                Status = false,
                User = "JuanK"
            });

            service.DeleteTicket(ticketAdded.Id);

            //Assert 
            Assert.NotEqual("", ticketAdded.Id);
        }


        private TicketDbConfig InitTicketConfig()
        {
            return new TicketDbConfig()
            {
                Connection_String = "mongodb://localhost:27018/test?compressors=disabled&gssapiServiceName=mongodb",
                Database_Name = "TicketsDb",
                Ticket_Collection_Name = "Tickets"
            };
        }
    }
}
