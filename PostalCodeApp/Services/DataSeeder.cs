using PostalCodeApp.Models;

namespace PostalCodeApp.Services
{
    public class DataSeeder
    {
        private readonly IAddressRepository _addressRepository;

        public DataSeeder(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task SeedDataAsync()
        {
            // Check if data already exists
            var existingAddresses = await _addressRepository.GetAllAddressesAsync();
            if (existingAddresses.Any())
            {
                return; // Data already seeded
            }

            // Sample UK addresses with postal codes
            var addresses = new List<Address>
            {
                new Address
                {
                    PostalCode = "SW1A 1AA",
                    Street = "Buckingham Palace",
                    City = "London",
                    County = "Greater London"
                },
                new Address
                {
                    PostalCode = "SW1A 2AA",
                    Street = "10 Downing Street",
                    City = "London",
                    County = "Greater London"
                },
                new Address
                {
                    PostalCode = "SW1W 0NY",
                    Street = "Victoria Street",
                    City = "London",
                    County = "Greater London"
                },
                new Address
                {
                    PostalCode = "EC1A 1BB",
                    Street = "St. Paul's Churchyard",
                    City = "London",
                    County = "Greater London"
                },
                new Address
                {
                    PostalCode = "EC2N 2DL",
                    Street = "Bank of England",
                    City = "London",
                    County = "Greater London"
                },
                new Address
                {
                    PostalCode = "M1 1AE",
                    Street = "Piccadilly Gardens",
                    City = "Manchester",
                    County = "Greater Manchester"
                },
                new Address
                {
                    PostalCode = "M1 2WD",
                    Street = "Deansgate",
                    City = "Manchester",
                    County = "Greater Manchester"
                },
                new Address
                {
                    PostalCode = "B1 1AA",
                    Street = "Victoria Square",
                    City = "Birmingham",
                    County = "West Midlands"
                },
                new Address
                {
                    PostalCode = "B2 4QA",
                    Street = "New Street",
                    City = "Birmingham",
                    County = "West Midlands"
                },
                new Address
                {
                    PostalCode = "LS1 1UR",
                    Street = "The Headrow",
                    City = "Leeds",
                    County = "West Yorkshire"
                },
                new Address
                {
                    PostalCode = "LS2 8JU",
                    Street = "Woodhouse Lane",
                    City = "Leeds",
                    County = "West Yorkshire"
                },
                new Address
                {
                    PostalCode = "EH1 1YZ",
                    Street = "Princes Street",
                    City = "Edinburgh",
                    County = "Midlothian"
                },
                new Address
                {
                    PostalCode = "EH2 2AN",
                    Street = "George Street",
                    City = "Edinburgh",
                    County = "Midlothian"
                },
                new Address
                {
                    PostalCode = "G1 1AA",
                    Street = "George Square",
                    City = "Glasgow",
                    County = "Lanarkshire"
                },
                new Address
                {
                    PostalCode = "G2 1DY",
                    Street = "Buchanan Street",
                    City = "Glasgow",
                    County = "Lanarkshire"
                }
            };

            foreach (var address in addresses)
            {
                await _addressRepository.AddAddressAsync(address);
            }
        }
    }
}
