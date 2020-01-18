using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicketApi.Models;

namespace TicketApi.Controllers
{
  [ApiController]
  [Route("tickets")]
  public class TicketController : ControllerBase
  {


    private readonly ILogger<TicketController> _logger;
    private readonly TicketContext _context;

    public TicketController(ILogger<TicketController> logger, TicketContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Ticket>> GetTickets()
    {
      var tickets = _context.Tickets;
      if (tickets.Count() == 0)
      {
        return NotFound("There are no tickets.");
      }
      else
      {
        return Ok(tickets.ToArray());
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ticket>> GetTickets(int id)
    {
      var ticket = await _context.Tickets.FindAsync(id);
      if (ticket == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(ticket);
      }
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<Ticket>> CreateTicket([FromBody] Ticket ticket)
    {
      if (ticket == null)
      {
        return BadRequest();
      }
      _context.Tickets.Add(ticket);
      await _context.SaveChangesAsync();

      return CreatedAtAction("CreateTicket", new { id = ticket.Id }, ticket);
    }
  }
}
