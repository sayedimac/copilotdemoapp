# UK Postal Code Address Lookup - MVP

This is a .NET 8.0 MVC web application that provides UK postal code address lookup functionality with Azure Table Storage backend.

## Features

- **Postal Code Search**: Type a UK postal code to dynamically filter addresses
- **Interactive Dropdown**: Integrated text box with dropdown that filters as you type
- **Address Details**: View complete address information upon selection
- **Azure Table Storage**: Backend storage using Azure Table Storage
- **Sample Data**: Pre-populated with sample UK addresses for demonstration

## Prerequisites

- .NET 8.0 SDK or higher
- Azure Storage Emulator (Azurite) for local development, or an Azure Storage account

## Getting Started

### Using Azure Storage Emulator (Azurite)

1. Install Azurite:
   ```bash
   npm install -g azurite
   ```

2. Start Azurite:
   ```bash
   azurite --silent --location /tmp --debug /tmp/debug.log
   ```

3. Run the application:
   ```bash
   cd PostalCodeApp
   dotnet run
   ```

### Using Azure Storage Account

1. Update the connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "AzureTableStorage": "DefaultEndpointsProtocol=https;AccountName=YOUR_ACCOUNT;AccountKey=YOUR_KEY;EndpointSuffix=core.windows.net"
     }
   }
   ```

2. Run the application:
   ```bash
   cd PostalCodeApp
   dotnet run
   ```

## Usage

1. Navigate to the Address Lookup page
2. Start typing a UK postal code (e.g., "SW1A", "M1", "EC1A")
3. The dropdown will automatically filter addresses matching your input
4. Select an address from the dropdown to view full details

## Architecture

- **Models**: `Address` entity implementing `ITableEntity` for Azure Table Storage
- **Services**: 
  - `IAddressRepository`: Interface for address operations
  - `AddressRepository`: Implementation using Azure Table Storage
  - `DataSeeder`: Seeds sample UK addresses on startup
- **Controllers**: `AddressController` handles search requests
- **Views**: Interactive UI with jQuery for dynamic filtering

## Sample Data

The application includes sample addresses from major UK cities:
- London (SW1A, EC1A, EC2N postal codes)
- Manchester (M1 postal codes)
- Birmingham (B1, B2 postal codes)
- Leeds (LS1, LS2 postal codes)
- Edinburgh (EH1, EH2 postal codes)
- Glasgow (G1, G2 postal codes)

## Technology Stack

- ASP.NET Core 8.0 MVC
- Azure.Data.Tables 12.11.0
- Bootstrap 5
- jQuery
- Azure Table Storage
