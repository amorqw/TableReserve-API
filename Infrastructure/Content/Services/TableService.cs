using Core.DtoS;
using Core.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Content.Services;

public class TableService: ITable
{
    private readonly ApplicationDbContext _context;

    public TableService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Table>> GetAllTables()
    {
        return await _context.Tables.ToListAsync();
    }

    public async Task<Table> GetTableById(Guid id)
    {
        return await _context.Tables.Where(t=> t.TableId == id).FirstOrDefaultAsync();
    }

    public async Task<Table> CreateTable(PostTableDto table)
    {
        var mapTableDto = MapDtoToTable(table);
        await _context.Tables.AddAsync(mapTableDto);
        await _context.SaveChangesAsync();
        return mapTableDto;
    }

    public async Task<Table> UpdateTable(Table table)
    {
         _context.Tables.Update(table);
        await _context.SaveChangesAsync();
        return table;
    }

    public async Task<Table> DeleteTable(Table table)
    {
        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();
        return table;
        
    }

    public async Task<bool> TableExists(Guid id)
    {
        return await _context.Tables.AnyAsync(t => t.TableId == id);
    }
    private static Table MapDtoToTable(PostTableDto tableDto)
    {
        return new Table
        {
            TableId = tableDto.TableId,
            SeatCount = tableDto.SeatCount,
            IsAvailable = tableDto.IsAvailable,
        };
    }
    
}