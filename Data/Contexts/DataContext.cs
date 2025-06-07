using Microsoft.EntityFrameworkCore;
using Data.Entities;
using System.Collections.Generic;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<AccountEntity> Account { get; set; } = null!;

}
