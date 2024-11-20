using APIProject.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Content.Services;

public class UserService: IUser
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetById(Guid id)
    {
        return await _context.Users.Where(u=> u.UserId == id).FirstOrDefaultAsync();
    }

    public async Task<User> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        return user;
    }

    public async Task<User> DeleteUser(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
        return user;
    }

    public async Task<bool> UserExists(Guid id)
    {
        return await _context.Users.AnyAsync(u => u.UserId == id);
    }
}