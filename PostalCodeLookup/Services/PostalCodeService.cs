using Azure.Data.Tables;
using PostalCodeLookup.Models;

namespace PostalCodeLookup.Services;

public class PostalCodeService : IPostalCodeService
{
    private readonly TableClient _tableClient;
    private readonly ILogger<PostalCodeService> _logger;
    private const string TableName = "PostalCodes";

    public PostalCodeService(IConfiguration configuration, ILogger<PostalCodeService> logger)
    {
        _logger = logger;
        var connectionString = configuration.GetConnectionString("AzureTableStorage");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            // Use development storage emulator if no connection string is provided
            connectionString = "UseDevelopmentStorage=true";
        }
        
        var serviceClient = new TableServiceClient(connectionString);
        _tableClient = serviceClient.GetTableClient(TableName);
        _tableClient.CreateIfNotExists();
    }

    public async Task<List<string>> GetAddressesByPostalCodeAsync(string postalCode)
    {
        try
        {
            var addresses = new List<string>();
            
            // Validate and sanitize postal code input
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                return addresses;
            }
            
            // Remove any potentially dangerous characters for OData filter
            var sanitizedPostalCode = postalCode.Replace("'", "''").Trim();
            
            // Query for all entities with the given postal code as partition key
            await foreach (var entity in _tableClient.QueryAsync<PostalCodeEntity>(
                filter: $"PartitionKey eq '{sanitizedPostalCode}'"))
            {
                addresses.Add($"{entity.Address}, {entity.City}, {entity.State}");
            }
            
            return addresses;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving addresses for postal code {PostalCode}", postalCode);
            return new List<string>();
        }
    }

    public async Task InitializeSampleDataAsync()
    {
        try
        {
            // Check if data already exists
            var existingData = _tableClient.QueryAsync<PostalCodeEntity>(maxPerPage: 1);
            await foreach (var _ in existingData)
            {
                _logger.LogInformation("Sample data already exists");
                return; // Data already exists
            }

            // Add sample data
            var sampleData = new[]
            {
                new PostalCodeEntity { PartitionKey = "10001", RowKey = Guid.NewGuid().ToString(), Address = "123 Main St", City = "New York", State = "NY" },
                new PostalCodeEntity { PartitionKey = "10001", RowKey = Guid.NewGuid().ToString(), Address = "456 Broadway", City = "New York", State = "NY" },
                new PostalCodeEntity { PartitionKey = "10001", RowKey = Guid.NewGuid().ToString(), Address = "789 5th Ave", City = "New York", State = "NY" },
                new PostalCodeEntity { PartitionKey = "90210", RowKey = Guid.NewGuid().ToString(), Address = "100 Beverly Dr", City = "Beverly Hills", State = "CA" },
                new PostalCodeEntity { PartitionKey = "90210", RowKey = Guid.NewGuid().ToString(), Address = "200 Rodeo Dr", City = "Beverly Hills", State = "CA" },
                new PostalCodeEntity { PartitionKey = "60601", RowKey = Guid.NewGuid().ToString(), Address = "300 Michigan Ave", City = "Chicago", State = "IL" },
                new PostalCodeEntity { PartitionKey = "60601", RowKey = Guid.NewGuid().ToString(), Address = "400 State St", City = "Chicago", State = "IL" },
                new PostalCodeEntity { PartitionKey = "98101", RowKey = Guid.NewGuid().ToString(), Address = "500 Pike St", City = "Seattle", State = "WA" },
                new PostalCodeEntity { PartitionKey = "98101", RowKey = Guid.NewGuid().ToString(), Address = "600 1st Ave", City = "Seattle", State = "WA" },
            };

            foreach (var entity in sampleData)
            {
                await _tableClient.AddEntityAsync(entity);
            }

            _logger.LogInformation("Sample data initialized successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error initializing sample data");
        }
    }
}
