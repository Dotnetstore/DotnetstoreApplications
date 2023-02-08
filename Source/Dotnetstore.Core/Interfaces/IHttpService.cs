using Dotnetstore.Core.Services;

namespace Dotnetstore.Core.Interfaces;

public interface IHttpService
{
    Task<HttpResponseWrapper<T>> GetAsync<T>(string url);

    Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T data);

    Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string url, T data);

    Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T data);

    Task<HttpResponseWrapper<object>> DeleteAsync<T>(string url);
}