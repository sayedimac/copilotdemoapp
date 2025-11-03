using PostalCodeApp.Models;

namespace PostalCodeApp.Services
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<IEnumerable<Address>> SearchByPostalCodeAsync(string postalCode);
        Task AddAddressAsync(Address address);
    }
}
