# Testing Guide

This document provides guidance on testing the UK Postal Code Address Lookup application.

## Manual Testing

### Prerequisites
- .NET 8.0 SDK or higher
- A web browser

### Starting the Application

```bash
cd PostalCodeApp
dotnet run
```

The application will start on `http://localhost:5000`

### Test Scenarios

#### 1. View All Addresses
**Steps:**
1. Navigate to `http://localhost:5000`
2. Observe the dropdown showing all 15 addresses

**Expected Result:**
- All addresses are listed in the dropdown
- Addresses are formatted as: `{PostalCode} - {Street}, {City}`

#### 2. Filter by Postal Code - "SW1"
**Steps:**
1. Type "SW1" in the Postal Code text box
2. Observe the dropdown

**Expected Result:**
- Dropdown shows only 3 addresses:
  - SW1A 1AA - Buckingham Palace, London
  - SW1A 2AA - 10 Downing Street, London
  - SW1W 0NY - Victoria Street, London

#### 3. Filter by Postal Code - "M1"
**Steps:**
1. Clear the text box or type "M1"
2. Observe the dropdown

**Expected Result:**
- Dropdown shows only 2 addresses:
  - M1 1AE - Piccadilly Gardens, Manchester
  - M1 2WD - Deansgate, Manchester

#### 4. Filter by Postal Code - "EC"
**Steps:**
1. Type "EC" in the Postal Code text box
2. Observe the dropdown

**Expected Result:**
- Dropdown shows 2 addresses:
  - EC1A 1BB - St. Paul's Churchyard, London
  - EC2N 2DL - Bank of England, London

#### 5. Select an Address
**Steps:**
1. Type a postal code to filter (e.g., "SW1")
2. Click on any address in the dropdown
3. Observe the "Selected Address" section below

**Expected Result:**
- The selected address details are displayed showing:
  - Street
  - City
  - County
  - Postal Code
  - Country

#### 6. Case Insensitive Search
**Steps:**
1. Type "sw1" (lowercase) in the text box
2. Type "SW1" (uppercase) in the text box

**Expected Result:**
- Both produce the same filtered results
- Filtering is case-insensitive

#### 7. No Matches
**Steps:**
1. Type "XYZ123" (non-existent postal code)
2. Observe the dropdown

**Expected Result:**
- Dropdown shows "No addresses found"

#### 8. Clear Search
**Steps:**
1. Type a postal code to filter
2. Clear the text box completely
3. Observe the dropdown

**Expected Result:**
- All addresses are shown again

## Browser Compatibility

Test the application in the following browsers:
- ✅ Google Chrome (latest)
- ✅ Mozilla Firefox (latest)
- ✅ Microsoft Edge (latest)
- ✅ Safari (latest)

## Performance Testing

### Response Time
- Filtering should respond within 100-200ms on localhost
- AJAX requests should complete quickly

### Usability
- Text box should be responsive to typing
- Dropdown should update smoothly without flickering
- Selection should be immediate

## Known Issues

None at this time.

## Reporting Issues

If you encounter any issues during testing, please provide:
1. Browser and version
2. Steps to reproduce
3. Expected vs actual behavior
4. Screenshots if applicable
