using Business.Models;
using Business.Services;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAccountService AccountService) : ControllerBase
{
    private readonly IAccountService _accountService = AccountService;

     [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _accountService.GetAccountsAsync();
        return Ok(accounts);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var currentAccount = await _accountService.GetAccountAsync(id);
        return currentAccount != null ? Ok(currentAccount) : NotFound();

    }

    [HttpPost("signup")]
    public async Task<IActionResult> Create(CreateAccountRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _accountService.CreateAccountAsync(request);
        return result.Success ? Ok(new { }) : StatusCode(StatusCodes.Status500InternalServerError, "Unable to create Account.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _accountService.LoginAsync(request);

        if (!result.Success)
            return Unauthorized(new { error = result.Error });

        return Ok(new { token = result.Token });
    }

}



   


  