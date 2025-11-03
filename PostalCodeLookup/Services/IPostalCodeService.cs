namespace PostalCodeLookup.Services;

public interface IPostalCodeService
{
    Task<List<string>> GetAddressesByPostalCodeAsync(string postalCode);
    Task InitializeSampleDataAsync();
}
