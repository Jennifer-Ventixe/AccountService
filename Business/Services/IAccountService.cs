using Business.Models;

namespace Business.Services
{
    public interface IAccountService
    {
        Task<AccountResult> CreateAccountAsync(CreateAccountRequest request);
        Task<AccountResult<Account?>> GetAccountAsync(string accountId);
        Task<AccountResult<IEnumerable<Account>>> GetAccountsAsync();

        Task<LoginResult> LoginAsync(LoginRequest request);
    }
}