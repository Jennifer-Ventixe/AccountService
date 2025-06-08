using Data.Entities;

namespace Data.Repositories
{
    public interface IAccountRepository : IBaseRepository<AccountEntity>
    {
        Task<AccountEntity?> GetByEmailAsync(string email);
    }
}