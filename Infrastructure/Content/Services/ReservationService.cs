using Core.DtoS;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Content.Services;

public class ReservationService:IReservation
{
    private readonly ApplicationDbContext _context;

    public ReservationService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Reservation>> GetAllReservations()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation> GetReservationById(Guid id)
    {
        return await _context.Reservations.Where(t=> t.ReservationId == id).FirstOrDefaultAsync();
    }

    public async Task<Reservation> CreateReservation(ReservationDto reservation)
    {
        var mapDtoToReservation = MapDtoToReservation(reservation);
        await _context.Reservations.AddAsync(mapDtoToReservation);
       await  _context.SaveChangesAsync();
       return mapDtoToReservation;
    }

    public async Task<Reservation> UpdateReservation(UpdateReservationDto updateReservationDto, Guid id)
    {
        var resid= await GetReservationById(id);
        if (resid == null)
            return null;
        resid.UserId = updateReservationDto.UserId;
        resid.TableId = updateReservationDto.TableId;
        resid.ReservationDate = updateReservationDto.ReservationDate;
        resid.Status = (Reservation.ReservationStatus)updateReservationDto.Status;
        _context.Reservations.Update(resid);
       await _context.SaveChangesAsync();
       return resid;
    }

    public async Task<Reservation> DeleteReservation(Reservation reservation)
    {
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
        return reservation;
    }

    public async Task<bool> ReservationExists(Guid id)
    {
        return await _context.Reservations.AnyAsync(t => t.ReservationId == id);
    }

    public static Reservation MapDtoToReservation(ReservationDto reservationDto)
    {
        return new Reservation
        {
            ReservationId = reservationDto.ReservationId,
            UserId = reservationDto.UserId,
            TableId = reservationDto.TableId,
            ReservationDate = reservationDto.ReservationDate,
            Status = (Reservation.ReservationStatus)reservationDto.Status // Преобразуем тип статуса
        };
    }
}