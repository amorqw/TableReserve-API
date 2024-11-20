using Core.Entities;
namespace APIProject.Interfaces;

public interface IUser
{
    Task<List<User>> GetAll();
    Task<User> GetById(Guid id);
    Task<User> AddUser(User model);
    Task<User> UpdateUser(User model);
    Task<User> DeleteUser(User model);
    Task<bool> UserExists(Guid id);
    
}