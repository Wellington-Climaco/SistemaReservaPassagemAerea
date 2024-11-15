using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ReservaPassagem.Application.Interface;
using ReservaPassagem.Application.Request;
using ReservaPassagem.Application.Services;
using ReservaPassagem.Application.Validators;

namespace ReservaPassagem.Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IValidator<RegisterUserRequest> _registerUserValidator;
    private readonly IValidator<AuthUserRequest> _authValidator;

    public UserController(IUserService userService, IValidator<RegisterUserRequest> registerUserValidator, IValidator<AuthUserRequest> authValidator)
    {
        _userService = userService;
        _registerUserValidator = registerUserValidator;
        _authValidator = authValidator;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
    {
        var validation = _registerUserValidator.Validate(registerUserRequest);
        var errors = validation.Errors.Select(x => x.ErrorMessage);

        if (!validation.IsValid)
            return BadRequest(errors);
        
        var result = await _userService.RegisterUser(registerUserRequest);

        if (result.IsFailed)
        {
            var resultErrors = result.Errors.Select(x => x.Message).ToList();
            return BadRequest(result.Errors);
        }
        
        return Created("",result.Value);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Auth([FromBody] AuthUserRequest authUserRequest)
    {
        var validation = _authValidator.Validate(authUserRequest);
        var errors = validation.Errors.Select(x => x.ErrorMessage);

        if (!validation.IsValid)
            return BadRequest(errors);
        
        var result = await _userService.Login(authUserRequest);

        if (result.IsFailed)
        {
            var resultErrors = result.Errors.Select(x => x.Message).ToList();
            return BadRequest(resultErrors);
        }
            

        return Ok(result.Value);
    }
}