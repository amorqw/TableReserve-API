using Core.Entities;

namespace APIProject.DtoS;

public class UserDto
{
    public Guid UserId { get; set; }
    public string LastName { get; set; }=string.Empty;
    public string Email { get; set; }= string.Empty;
    public string? PhoneNumber { get; set; }
    
}