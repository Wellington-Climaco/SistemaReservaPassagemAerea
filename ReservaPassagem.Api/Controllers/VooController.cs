using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ReservaPassagem.Application.Interface;
using ReservaPassagem.Application.Request;
using ReservaPassagem.Application.Validators;

namespace ReservaPassagem.Api.Controllers;

[ApiController]
public class VooController : ControllerBase
{
    private readonly IVooService _vooService;
    private readonly IValidator<VooRequest> _validator;
    private readonly IValidator<ActiveVooRequest> _activeVooValidator;
    
    public VooController(IVooService vooService, IValidator<VooRequest> validator, IValidator<ActiveVooRequest> activeVooValidator)
    {
        _vooService = vooService;
        _validator = validator;
        _activeVooValidator = activeVooValidator;
    }
    
    [HttpPost("v1/cadastraVoo")]
    public async Task<IActionResult> CadastraVoo(VooRequest request)
    {
        var validation = _validator.Validate(request);
        var error = validation.Errors.Select(x => x.ErrorMessage);

        if (!validation.IsValid)
            return BadRequest(error);

        var result = await _vooService.AddVoo(request);

        if (result.IsT0)
        {
            return Created("",result.AsT0);
        }

        return BadRequest(result.AsT1);
    }

    [HttpPost("v1/ativarVoo")]
    public async Task<IActionResult> AtivarVoo(ActiveVooRequest vooNumber)
    {
        var validation = _activeVooValidator.Validate(vooNumber);
        var error = validation.Errors.Select(x => x.ErrorMessage);
        var result = await _vooService.ActiveVoo(vooNumber.ToString());

        if (!validation.IsValid)
        {
            return BadRequest(error);
        }
        
        if (result.IsT0)
        {
            return Ok(result.AsT0);
        }
        
        return BadRequest(result.AsT1);
    }
}