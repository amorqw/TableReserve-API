namespace Core.DtoS;

public class PostTableDto
{
    public Guid TableId { get; set; }
    public int SeatCount { get; set; }
    public bool IsAvailable { get; set; }
}