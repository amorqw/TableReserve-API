using Core.DtoS;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TableController(ITable tableService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Table>>> GetTables()
    {
        return Ok(await tableService.GetAllTables());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Table>> GetTable(Guid id)
    {
        var table = await tableService.GetTableById(id);
        if(table == null)
            return BadRequest($"No table found {id}");
        return Ok(table);
    }

    [HttpPost]
    public async Task<ActionResult<Table>> CreateTable([FromBody] PostTableDto postTableDto)
    {
        if( await tableService.TableExists(postTableDto.TableId))
            return BadRequest($"reservation with id {postTableDto.TableId} already exists");
        await tableService.CreateTable(postTableDto);
        return Ok($"Reservation {postTableDto.TableId} has been created");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTable(Guid id)
    {
        var table = await tableService.GetTableById(id);
        if(table == null)
            return BadRequest($"No table found {id}");
        await tableService.DeleteTable(table);
        return Ok($"table {id} deleted");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateTable(Guid id, UpdateTablesDto model)
    {
        var table  = await tableService.GetTableById(id);
        if(table == null)
            return BadRequest($"No table found {id}");
        table.IsAvailable = model.IsAvailable;
        await tableService.UpdateTable(table);
        return Ok($"table {id} updated");
    }
        
}