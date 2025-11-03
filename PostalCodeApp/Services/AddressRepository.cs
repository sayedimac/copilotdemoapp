using Azure.Data.Tables;
using PostalCodeApp.Models;

namespace PostalCodeApp.Services
{
    public class AddressRepository : IAddressRepository
    {
        private readonly TableClient _tableClient;
        private const string TableName = "Addresses";
        private const string PartitionKeyValue = "UK";

        public AddressRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AzureTableStorage") 
                ?? "UseDevelopmentStorage=true";
            
            var serviceClient = new TableServiceClient(connectionString);
            _tableClient = serviceClient.GetTableClient(TableName);
            _tableClient.CreateIfNotExists();
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            var addresses = new List<Address>();
            await foreach (var address in _tableClient.QueryAsync<Address>())
            {
                addresses.Add(address);
            }
            return addresses;
        }

        public async Task<IEnumerable<Address>> SearchByPostalCodeAsync(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                return await GetAllAddressesAsync();
            }

            var normalizedPostalCode = postalCode.Replace(" ", "").ToUpperInvariant();
            var addresses = new List<Address>();
            
            await foreach (var address in _tableClient.QueryAsync<Address>())
            {
                var normalizedAddressPostalCode = address.PostalCode.Replace(" ", "").ToUpperInvariant();
                if (normalizedAddressPostalCode.StartsWith(normalizedPostalCode))
                {
                    addresses.Add(address);
                }
            }
            
            return addresses;
        }

        public async Task AddAddressAsync(Address address)
        {
            address.PartitionKey = PartitionKeyValue;
            address.RowKey = Guid.NewGuid().ToString();
            await _tableClient.AddEntityAsync(address);
        }
    }
}
