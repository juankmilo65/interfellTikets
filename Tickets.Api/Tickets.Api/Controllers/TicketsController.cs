using Microsoft.AspNetCore.Mvc;
using Tickets.Core;

namespace Tickets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            return Ok(_ticketService.GetTickets());
        }

        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult GetTicket(string id)
        {
            return  Ok(_ticketService.GetTicket(id));
        }


        [HttpPost]
        public IActionResult AddTickets(Ticket ticket)
        {
            _ticketService.AddTicket(ticket);
            return CreatedAtRoute("GetTicket", new { id = ticket.Id }, ticket);
        }
    }
}
