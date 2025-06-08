using Data.Contexts;
using Data.Entities;

namespace Data.Repositories;

public class AccountRepository(DataContext context) : BaseRepository<AccountEntity>(context), IAccountRepository
{
}