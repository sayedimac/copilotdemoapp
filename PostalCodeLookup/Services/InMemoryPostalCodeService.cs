namespace PostalCodeLookup.Services;

public class InMemoryPostalCodeService : IPostalCodeService
{
    private readonly Dictionary<string, List<string>> _postalCodeData = new();
    private readonly ILogger<InMemoryPostalCodeService> _logger;

    public InMemoryPostalCodeService(ILogger<InMemoryPostalCodeService> logger)
    {
        _logger = logger;
    }

    public Task<List<string>> GetAddressesByPostalCodeAsync(string postalCode)
    {
        if (_postalCodeData.TryGetValue(postalCode, out var addresses))
        {
            return Task.FromResult(addresses);
        }
        return Task.FromResult(new List<string>());
    }

    public Task InitializeSampleDataAsync()
    {
        if (_postalCodeData.Count > 0)
        {
            _logger.LogInformation("Sample data already exists");
            return Task.CompletedTask;
        }

        _postalCodeData["10001"] = new List<string>
        {
            "123 Main St, New York, NY",
            "456 Broadway, New York, NY",
            "789 5th Ave, New York, NY"
        };

        _postalCodeData["90210"] = new List<string>
        {
            "100 Beverly Dr, Beverly Hills, CA",
            "200 Rodeo Dr, Beverly Hills, CA"
        };

        _postalCodeData["60601"] = new List<string>
        {
            "300 Michigan Ave, Chicago, IL",
            "400 State St, Chicago, IL"
        };

        _postalCodeData["98101"] = new List<string>
        {
            "500 Pike St, Seattle, WA",
            "600 1st Ave, Seattle, WA"
        };

        _logger.LogInformation("Sample data initialized successfully");
        return Task.CompletedTask;
    }
}
