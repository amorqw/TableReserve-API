namespace APIProject.Models;

public class Table
{
    public Guid TableId { get; set; }
    public int SeatCount { get; set; }
    public bool IsAvailable { get; set; }
    
    public List<Reservation> Reservations { get; set; }
    public Guid ReservationId { get; set; }
}