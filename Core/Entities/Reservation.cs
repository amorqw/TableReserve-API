namespace APIProject.Models;

public class Reservation
{
    public Guid ReservationId { get; set; }
    public Guid UserId { get; set; }
    public Guid TableId { get; set; }
    public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
    public ReservationStatus Status { get; set; }

    public User User { get; set; } = null!;
    public Table Table { get; set; } = null!;

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
}