using Core.DtoS;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TableController:ControllerBase
{
    private readonly ITable _tableService;

    public TableController(ITable tableService)
    {
        _tableService = tableService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Table>>> GetTables()
    {
        return Ok(await _tableService.GetAllTables());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Table>> GetTable(Guid id)
    {
        var table = await _tableService.GetTableById(id);
        if(table == null)
            return BadRequest($"No table found {id}");
        return Ok(table);
    }

    [HttpPost]
    public async Task<ActionResult<Table>> CreateTable([FromForm] Table table)
    {
        if (await _tableService.TableExists(table.TableId))
        {
            return BadRequest($"Table {table.TableId} already exists");
        }
        var result = await _tableService.CreateTable(table);
        return Ok(await _tableService.GetAllTables());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTable(Guid id)
    {
        var table = await _tableService.GetTableById(id);
        if(table == null)
            return BadRequest($"No table found {id}");
        await _tableService.DeleteTable(table);
        return Ok($"table {id} deleted");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateTable(Guid id, TablesDto model)
    {
        var table  = await _tableService.GetTableById(id);
        if(table == null)
            return BadRequest($"No table found {id}");
        table.IsAvailable = model.IsAvailable;
        await _tableService.UpdateTable(table);
        return Ok($"table {id} updated");
    }
        
}