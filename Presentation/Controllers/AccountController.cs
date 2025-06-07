using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(AccountService AccountService) : ControllerBase
{
    private readonly IAccountService _AccountService = AccountService;

    [HttpGet]
    public async Task<IActionResult> Create(CreateAccountRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _AccountService.CreateAccountAsync(request);
        return result.Success ? Ok() : StatusCode(StatusCodes.Status500InternalServerError, "Unable to create Account.");
    }

}

