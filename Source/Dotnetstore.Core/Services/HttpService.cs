using Dotnetstore.Core.Abstracts;
using Dotnetstore.Core.Interfaces;
using System.Text;
using System.Text.Json;

namespace Dotnetstore.Core.Services;

public sealed class HttpService : Disposable, IHttpService
{
    private readonly HttpClient _httpClient;

    public HttpService(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private static JsonSerializerOptions? JsonSerializerOptions => new()
    {
        PropertyNameCaseInsensitive = true
    };

    async Task<HttpResponseWrapper<T>> IHttpService.GetAsync<T>(string url)
    {
        var responseHTTP = await _httpClient.GetAsync(url);

        if (responseHTTP.IsSuccessStatusCode)
        {
            var response = await Deserialize<T>(responseHTTP, JsonSerializerOptions);
            return new HttpResponseWrapper<T>(true, response, responseHTTP);
        }

        return new HttpResponseWrapper<T>(false, default, responseHTTP);
    }

    async Task<HttpResponseWrapper<object>> IHttpService.PostAsync<T>(string url, T data)
    {
        var dataJson = JsonSerializer.Serialize(data);
        var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, stringContent);

        return new HttpResponseWrapper<object>(response.IsSuccessStatusCode, null, response);
    }

    async Task<HttpResponseWrapper<TResponse>> IHttpService.PostAsync<T, TResponse>(string url, T data)
    {
        var dataJson = JsonSerializer.Serialize(data);
        var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, stringContent);

        if (response.IsSuccessStatusCode)
        {
            var responseDeserialized = await Deserialize<TResponse>(response, JsonSerializerOptions);
            return new HttpResponseWrapper<TResponse>(true, responseDeserialized, response);
        }

        return new HttpResponseWrapper<TResponse>(false, default, response);
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _httpClient.Dispose();
        }

        base.DisposeManaged();
    }

    private static async Task<T?> Deserialize<T>(HttpResponseMessage httpResponseMessage,
                        JsonSerializerOptions? jsonSerializerOptions)
    {
        var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
    }

    async Task<HttpResponseWrapper<object>> IHttpService.PutAsync<T>(string url, T data)
    {
        var dataJson = JsonSerializer.Serialize(data);
        var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync(url, stringContent);

        return new HttpResponseWrapper<object>(response.IsSuccessStatusCode, null, response);
    }

    async Task<HttpResponseWrapper<object>> IHttpService.DeleteAsync<T>(string url)
    {
        var responseHttp = await _httpClient.DeleteAsync(url);
        return new HttpResponseWrapper<object>(responseHttp.IsSuccessStatusCode, null, responseHttp);
    }
}