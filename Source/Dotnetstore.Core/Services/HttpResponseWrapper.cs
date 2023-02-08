using Dotnetstore.Core.Abstracts;

namespace Dotnetstore.Core.Services;

public sealed class HttpResponseWrapper<T> : Disposable
{
    public bool Success { get; set; }

    public T Response { get; set; }

    public HttpResponseMessage HttpResponseMessage { get; set; }

    public HttpResponseWrapper(
        bool success, T response, HttpResponseMessage httpResponseMessage)
    {
        Success = success;
        Response = response;
        HttpResponseMessage = httpResponseMessage;
    }

    public async Task<string> GetBodyAsync()
    {
        return await HttpResponseMessage.Content.ReadAsStringAsync();
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            HttpResponseMessage.Dispose();
        }

        base.DisposeManaged();
    }
}