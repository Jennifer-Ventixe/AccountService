using Business.Models;
using Data.Contexts;

namespace Data.Repositories;

public class AccountRepository(DataContext context) : BaseRepository<Account>(context)
{
}