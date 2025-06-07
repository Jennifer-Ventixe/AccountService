

using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class AccountEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
