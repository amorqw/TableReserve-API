
namespace Core.Entities;

public class Table
{
    public Guid TableId { get; set; }
    public int SeatCount { get; set; }
    public bool IsAvailable { get; set; }
    
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
}