using Core.DtoS;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReservationController: ControllerBase
{
    private readonly IReservation _reservationService;

    public ReservationController(IReservation reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Reservation>>> GetReservations()
    {
        return Ok(await _reservationService.GetAllReservations());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Reservation>> GetReservation(Guid id)
    {
        var reservation = await _reservationService.GetReservationById(id);
        if (reservation == null)
            return BadRequest("Reservation not found");
        return reservation;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation([FromBody] ReservationDto reservationDto)
    {
        if( await _reservationService.ReservationExists(reservationDto.ReservationId))
            return BadRequest($"reservation with id {reservationDto.ReservationId} already exists");
        await _reservationService.CreateReservation(reservationDto);
        return Ok($"Reservation {reservationDto.ReservationId} has been created");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(Guid id, [FromBody] UpdateReservationDto model)
    {
        var reservation = await _reservationService.UpdateReservation(model, id);
        if(reservation == null)
            return BadRequest($"reservation with id {id} not exists");
        return Ok($"Reservation {id} has been updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(Guid id)
    {
        var reservation = await _reservationService.GetReservationById(id);
        if (reservation == null)
            return BadRequest("Reservation not found");
        return Ok(await _reservationService.DeleteReservation(reservation));
    }
}