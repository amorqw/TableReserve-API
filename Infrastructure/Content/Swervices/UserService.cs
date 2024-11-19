using APIProject.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Content.Swervices;

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
}