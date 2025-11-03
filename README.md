# copilotdemoapp

UK Postal Code Address Lookup - A .NET 8.0 MVC web application with Azure Table Storage backend.

## Overview

This application demonstrates a web-based UK postal code address lookup system with the following features:

- **Real-time Postal Code Filtering**: Type a UK postal code to dynamically filter addresses
- **Integrated Dropdown with Text Box**: Seamless user experience with combined search and selection
- **Azure Table Storage Backend**: Production-ready with Azure Table Storage integration
- **In-Memory Mode**: Easy testing and demonstration without Azure setup required
- **Sample Data**: Pre-populated with 15 sample UK addresses from major cities

## Quick Start

1. Navigate to the application directory:
   ```bash
   cd PostalCodeApp
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. Open your browser and navigate to `http://localhost:5000`

4. Start typing a UK postal code (e.g., "SW1", "M1", "B1") to see the filtering in action

## Project Structure

```
PostalCodeApp/
├── Controllers/          # MVC Controllers (AddressController)
├── Models/              # Data models (Address entity)
├── Services/            # Business logic and data access
│   ├── IAddressRepository.cs
│   ├── AddressRepository.cs         # Azure Table Storage implementation
│   ├── InMemoryAddressRepository.cs # In-memory implementation
│   └── DataSeeder.cs                # Sample data seeding
├── Views/               # Razor views
│   └── Address/
│       └── Index.cshtml # Main address lookup page
└── wwwroot/            # Static files (CSS, JS, libraries)
```

## Configuration

By default, the application uses in-memory storage for easy demonstration. To use Azure Table Storage:

1. Open `appsettings.json`
2. Set `UseAzureTableStorage` to `true`
3. Configure your Azure Storage connection string

```json
{
  "UseAzureTableStorage": true,
  "ConnectionStrings": {
    "AzureTableStorage": "YOUR_AZURE_STORAGE_CONNECTION_STRING"
  }
}
```

## Technologies Used

- ASP.NET Core 8.0 MVC
- Azure.Data.Tables SDK
- Bootstrap 5
- jQuery
- Azure Table Storage (optional)

## Sample Data

The application includes sample addresses from:
- London (SW1A, EC1A, EC2N)
- Manchester (M1)
- Birmingham (B1, B2)
- Leeds (LS1, LS2)
- Edinburgh (EH1, EH2)
- Glasgow (G1, G2)

For more details, see the [PostalCodeApp README](PostalCodeApp/README.md).
