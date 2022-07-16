using System.Net.Http.Headers;
using Blazored.SessionStorage;

namespace UI.Logic;

/// <summary>
/// Custom delegating handler for adding Auth headers to outbound requests
/// </summary>
public class AuthHeaderHandler : DelegatingHandler
{
    private readonly ISessionStorageService _sessionStorageService;

    public AuthHeaderHandler(ISessionStorageService sessionStorageService)
    {
        _sessionStorageService = sessionStorageService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _sessionStorageService.GetItemAsStringAsync("token");

        // TODO: potentially refresh token here if it has expired etc.

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}