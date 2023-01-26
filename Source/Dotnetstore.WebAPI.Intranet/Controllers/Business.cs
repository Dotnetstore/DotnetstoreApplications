using Dotnetstore.Shared.Business;
using Dotnetstore.UnitOfWorks.Intranet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dotnetstore.WebAPI.Intranet.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class Business : ControllerBase, IDisposable
{
    private readonly IUnitOfWorks _unitOfWorks;
    private bool _disposed;

    public Business(
        IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    /// <summary>
    ///     Add a new own company.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///
    ///     POST /api/Business/OwnCompanyAdd { "Name": "Dotnetstore", "Description": "My own
    ///     company", "CorporateID": "123456-7890", "UserID": "938EF7E9-2E40-4998-9DC7-BA4FB53FE9BA" }
    /// </remarks>
    /// <param name="ownCompanyAddRequestDto">OwnCompanyAddRequestDto</param>
    /// <returns>OwnCompanyAddResponseDto</returns>
    /// POST: /api/Business/OwnCompanyAdd
    [HttpPost]
    public async Task<ActionResult> OwnCompanyAddAsync([FromBody] OwnCompanyAddRequestDto ownCompanyAddRequestDto)
    {
        var result = await _unitOfWorks.Business.OwnCompany.AddAsync(ownCompanyAddRequestDto);
        return Ok(result);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
        }

        _disposed = true;
    }
}