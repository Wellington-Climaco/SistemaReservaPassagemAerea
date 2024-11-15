using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ReservaPassagem.Application.Errors;
using ReservaPassagem.Application.Extensions;
using ReservaPassagem.Application.Interface;
using ReservaPassagem.Application.Request;
using ReservaPassagem.Application.Validators;

namespace ReservaPassagem.Api.Controllers;

[ApiController]
public class VooController : ControllerBase
{
    private readonly IVooService _vooService;
    private readonly IValidator<VooRequest> _validator;
    
    public VooController(IVooService vooService, IValidator<VooRequest> validator)
    {
        _vooService = vooService;
        _validator = validator;
    }
    
    [HttpPost("v1/cadastraVoo")]
    public async Task<IActionResult> CadastraVoo(VooRequest request)
    {
        var validation = _validator.Validate(request);
        var error = validation.Errors.Select(x => x.ErrorMessage);

        if (!validation.IsValid)
            return BadRequest(error);

        var result = await _vooService.AddVoo(request);

        if (result.IsSucess())
        {
            return Created("",result.GetSucessResult());
        }

        return BadRequest(result.GetErrorResult());
    }

    [HttpPut("v1/voo/{vooNumber}/ativar")]
    public async Task<IActionResult> AtivarVoo(string vooNumber)
    {
        var result = await _vooService.ActiveVoo(vooNumber);
        
        if (result.IsSucess())
        {
            return Ok(result.GetSucessResult());
        }

        var errorResult = result.GetErrorResult();

        if (errorResult.TypeError.Equals(ErrorType.NotFound.ToString()))
            return NotFound(errorResult);
        
        if(errorResult.TypeError.Equals(ErrorType.Conflict.ToString()))
            return Conflict(errorResult);

        return BadRequest(errorResult);
    }

    [HttpPut("v1/voo/{vooNumber}/desabilitar")]
    public async Task<IActionResult> DesabilitarVoo(string vooNumber)
    {
        var result = await _vooService.DisableVoo(vooNumber);
        
        if(result.IsSucess())
            return Ok(result.GetSucessResult());
        
        var errorResult = result.GetErrorResult();
        
        if (errorResult.TypeError.Equals(ErrorType.NotFound.ToString()))
            return NotFound(errorResult);
        
        if(errorResult.TypeError.Equals(ErrorType.Conflict.ToString()))
            return Conflict(errorResult);
        
        return BadRequest(errorResult); 
    }

    [HttpGet("v1/voo/cidade/{origem}")]
    public async Task<IActionResult> GetVooByCityOrigin([FromRoute] string origem)
    {
        var result = await _vooService.GetByCityOrigin(origem);

        if (result.IsSucess())
            return Ok(result.GetSucessResult());
        
        var errorResult = result.GetErrorResult();

        if (errorResult.TypeError.Equals(ErrorType.NotFound.ToString()))
            return NotFound(errorResult);

        return BadRequest(errorResult);
    }
    
    [HttpGet("v1/voo/cidade/{destino}")]
    public async Task<IActionResult> GetVooByCityDestination([FromRoute]string destino)
    {
        var result = await _vooService.GetByCityDestination(destino);

        if (result.IsSucess())
            return Ok(result.GetSucessResult());
        
        var errorResult = result.GetErrorResult();

        if (errorResult.TypeError.Equals(ErrorType.NotFound.ToString()))
            return NotFound(errorResult);

        return BadRequest(errorResult);
    }
}