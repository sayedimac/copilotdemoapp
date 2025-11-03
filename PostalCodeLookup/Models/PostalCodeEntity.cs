using Azure;
using Azure.Data.Tables;

namespace PostalCodeLookup.Models;

public class PostalCodeEntity : ITableEntity
{
    public string PartitionKey { get; set; } = string.Empty; // Will be the postal code
    public string RowKey { get; set; } = string.Empty; // Will be a unique identifier for each address
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
}
