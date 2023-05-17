public class DemoLoggingHandler : DelegatingHandler
{
    private readonly ILogger<DemoLoggingHandler> _logger;

    public DemoLoggingHandler(ILogger<DemoLoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"HTTP request sent {request.Method} {request.RequestUri}");
        var response = await base.SendAsync(request, cancellationToken);
        _logger.LogInformation($"HTTP response received :{response.StatusCode}");
        return response;
    }
}
