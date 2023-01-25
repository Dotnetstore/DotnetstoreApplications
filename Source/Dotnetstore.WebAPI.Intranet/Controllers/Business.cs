using Microsoft.AspNetCore.Mvc;

namespace Dotnetstore.WebAPI.Intranet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Business : ControllerBase, IDisposable
{
    private bool _disposed;

    public Business()
    {

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