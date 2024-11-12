
namespace Core.Entities;

public class Table
{
    public Guid TableId { get; set; }
    public int SeatCount { get; set; }
    public bool IsAvailable { get; set; }
    
    public Guid ReservationId { get; set; }
    public Reservation? Reservation { get; set; }
}