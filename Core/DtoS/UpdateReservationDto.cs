namespace Core.DtoS;

public class UpdateReservationDto
{
    public Guid UserId { get; set; }
    public Guid TableId { get; set; }
    public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
    public ReservationEnum.ReservationStatuss Status { get; set; }
}