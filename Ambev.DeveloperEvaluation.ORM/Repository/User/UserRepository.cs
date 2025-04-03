using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repository.User;

public class UserRepository : IUserRepository
{
    #region attributes
    
    private readonly DefaultContext _context;

    #endregion

    #region constructors

    public UserRepository(DefaultContext context) => _context = context;

    #endregion

    #region methods

    public async Task<UserEntity> CreateAsync(UserEntity user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<UserEntity> UpdateAsync(UserEntity user, CancellationToken cancellationToken)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await GetByIdAsync(id, cancellationToken);
        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<UserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

    public async Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Users.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken cancellationToken)
        => await _context.Users.ToListAsync(cancellationToken);

    #endregion
}
