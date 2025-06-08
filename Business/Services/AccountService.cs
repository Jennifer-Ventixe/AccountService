using Business.Models;
using Data.Entities;
using Data.Repositories;

namespace Business.Services;

public class AccountService(IAccountRepository accountRepository) : IAccountService
{
    private readonly IAccountRepository _accountRepository = accountRepository;

    public async Task<AccountResult> CreateAccountAsync(CreateAccountRequest request)
    {
        try
        {
            var accountEntity = new AccountEntity
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password

            };

            var result = await _accountRepository.AddAsync(accountEntity);
            return result.Success
                ? new AccountResult { Success = true }
                : new AccountResult { Success = false, Error = result.Error };
        }

        catch (Exception ex) { 


            return new AccountResult
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public async Task<AccountResult<IEnumerable<Account>>> GetAccountsAsync()
    {
        var result = await _accountRepository.GetAllAsync();
        var accounts = result.Result?.Select(x => new Account
        {
            Id = x.Id,
            UserName = x.UserName,
            Email = x.Email,
            Password = x.Password
        });

        return new AccountResult<IEnumerable<Account>> { Success = true, Result = accounts };
    }




    public async Task<AccountResult<Account?>> GetAccountAsync(string accountId)
    {
        var result = await _accountRepository.GetAsync(x => x.Id == accountId);
        if (result.Success && result.Result != null)
        {
            var currentAccount = new Account
            {
                Id = result.Result.Id,
                UserName = result.Result.UserName,
                Email = result.Result.Email,
                Password = result.Result.Password
            };
            return new AccountResult<Account?> { Success = true, Result = currentAccount };
        }

        return new AccountResult<Account?> { Success = false, Error = result.Error ?? "Account not found." };

    }

    public async Task<LoginResult> LoginAsync(LoginRequest request) // tgait hjälp av chatgpt med koden
    {
        var account = await _accountRepository.GetByEmailAsync(request.Email);

        if (account == null || account.Password != request.Password) 
        {
            return new LoginResult
            {
                Success = false,
                Error = "Invalid username or password"
            };
        }

        
        var token = $"fake-token-for-{account.Id}";

        return new LoginResult
        {
            Success = true,
            Token = token
        };
    }
}
