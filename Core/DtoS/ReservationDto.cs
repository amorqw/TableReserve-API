using Core.Entities;

namespace Core.DtoS;

public class ReservationDto : ReservationEnum
{
    public Guid ReservationId { get; set; }
    public Guid UserId { get; set; }
    public Guid TableId { get; set; }
    public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
    public ReservationStatuss Status { get; set; }
}