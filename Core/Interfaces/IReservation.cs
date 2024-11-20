using Core.DtoS;
using Core.Entities;

namespace Core.Interfaces;

public interface IReservation
{
    Task<List<Reservation>> GetAllReservations();
    Task<Reservation> GetReservationById(Guid id);
    Task<Reservation> CreateReservation(ReservationDto reservation);
    Task<Reservation> UpdateReservation(UpdateReservationDto reservation, Guid id);
    Task<Reservation> DeleteReservation(Reservation reservation);
    Task<bool> ReservationExists(Guid id);
}