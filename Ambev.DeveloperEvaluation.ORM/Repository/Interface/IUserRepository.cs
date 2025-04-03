using Ambev.DeveloperEvaluation.Domain.Model;
namespace Ambev.DeveloperEvaluation.ORM.Repository.Interface;

public interface IUserRepository
{
	#region methods

	Task<UserEntity> CreateAsync(UserEntity user, CancellationToken cancellationToken);
    Task<UserEntity> UpdateAsync(UserEntity user, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    #endregion
}
