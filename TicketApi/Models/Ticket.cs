using System;

namespace TicketApi.Models
{
  public class Ticket
  {
    public int Id { get; set; }

    public string Author { get; set; }
    
    public DateTime Date { get; set; }

    public string Message { get; set; }

    public string Status { get; set; }

    public string Summary { get; set; }
  }
}
