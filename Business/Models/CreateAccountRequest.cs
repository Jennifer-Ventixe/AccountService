

namespace Business.Models;

public class CreateAccountRequest
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
