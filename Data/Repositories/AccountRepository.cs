using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class AccountRepository(DataContext context) : BaseRepository<AccountEntity>(context), IAccountRepository
{

    public async Task<AccountEntity?> GetByEmailAsync(string email)
    {
        return await _context.Account.FirstOrDefaultAsync(a => a.Email == email);
    }
}
