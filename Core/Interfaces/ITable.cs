using Core.Entities;
namespace Core.Interfaces;


public interface ITable
{
    Task<List<Table>> GetAllTables();
    Task<Table> GetTableById(Guid id);
    Task<Table> CreateTable(Table table);
    Task<Table> UpdateTable(Table table);
    Task<Table> DeleteTable(Table table);
    Task<bool> TableExists(Guid id);
}