# copilotdemoapp

A simple web-based application that interacts with Azure Table Storage to provide postal code to address lookups. Users can type in a postal code and see a dropdown list of all addresses associated with that postal code.

## Features

- Real-time postal code search with autocomplete
- Integration with Azure Table Storage for data persistence
- Responsive web interface using Bootstrap
- Sample data pre-loaded for testing (postal codes: 10001, 90210, 60601, 98101)

## Prerequisites

- .NET 8.0 SDK or later
- Azure Storage Account (or use Azure Storage Emulator/Azurite for local development)

## Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/sayedimac/copilotdemoapp.git
cd copilotdemoapp
```

### 2. Configure Azure Table Storage

For local development, the app is configured to use the Azure Storage Emulator by default (`UseDevelopmentStorage=true`).

To use an actual Azure Storage Account:
1. Create an Azure Storage Account in the Azure Portal
2. Copy the connection string
3. Update the connection string in `PostalCodeLookup/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "AzureTableStorage": "DefaultEndpointsProtocol=https;AccountName=YOUR_ACCOUNT_NAME;AccountKey=YOUR_ACCOUNT_KEY;EndpointSuffix=core.windows.net"
  }
}
```

Or use environment variables:
```bash
export ConnectionStrings__AzureTableStorage="YOUR_CONNECTION_STRING"
```

### 3. Run the application

```bash
cd PostalCodeLookup
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`.

### 4. Using the application

1. Open your browser and navigate to the application URL
2. Type a postal code in the input field (try: 10001, 90210, 60601, or 98101)
3. As you type, the application will display a list of addresses matching the postal code
4. Sample data is automatically loaded on first run

## Project Structure

```
PostalCodeLookup/
├── Models/
│   └── PostalCodeEntity.cs       # Azure Table Storage entity
├── Services/
│   └── PostalCodeService.cs      # Service for postal code operations
├── Pages/
│   ├── Index.cshtml              # Main page with postal code lookup UI
│   └── Index.cshtml.cs           # Page model with search handler
├── Program.cs                     # Application entry point
└── appsettings.json              # Configuration including connection string
```

## Sample Data

The application includes sample data for the following postal codes:
- **10001** (New York, NY) - 3 addresses
- **90210** (Beverly Hills, CA) - 2 addresses
- **60601** (Chicago, IL) - 2 addresses
- **98101** (Seattle, WA) - 2 addresses

## Technologies Used

- ASP.NET Core 8.0 (Razor Pages)
- Azure Table Storage SDK
- Bootstrap 5 for UI
- JavaScript for client-side interactivity

## License

This project is licensed under the MIT License - see the LICENSE file for details.