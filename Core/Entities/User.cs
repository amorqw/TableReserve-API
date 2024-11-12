using System.ComponentModel.DataAnnotations;

namespace APIProject.Models;

public class User
{
    public Guid UserId { get; set; }
    [Required]
    public string FirstName { get; set; }=string.Empty;
    [Required]
    public string LastName { get; set; }=string.Empty;
    public string Email { get; set; }= string.Empty;
    [Required]
    public string Password { get; set; }=string.Empty;
    public string? PhoneNumber { get; set; }
    
    public List<Reservation> Reservations { get; set; }
    public Guid ReservationId { get; set; }
    
}