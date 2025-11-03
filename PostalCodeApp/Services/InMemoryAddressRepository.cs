using PostalCodeApp.Models;

namespace PostalCodeApp.Services
{
    public class InMemoryAddressRepository : IAddressRepository
    {
        private readonly List<Address> _addresses = new();

        public Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return Task.FromResult<IEnumerable<Address>>(_addresses);
        }

        public Task<IEnumerable<Address>> SearchByPostalCodeAsync(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                return Task.FromResult<IEnumerable<Address>>(_addresses);
            }

            var normalizedPostalCode = postalCode.Replace(" ", "").ToUpperInvariant();
            var results = _addresses
                .Where(a => a.PostalCode.Replace(" ", "").ToUpperInvariant().StartsWith(normalizedPostalCode))
                .ToList();

            return Task.FromResult<IEnumerable<Address>>(results);
        }

        public Task AddAddressAsync(Address address)
        {
            address.PartitionKey = "UK";
            address.RowKey = Guid.NewGuid().ToString();
            _addresses.Add(address);
            return Task.CompletedTask;
        }
    }
}
