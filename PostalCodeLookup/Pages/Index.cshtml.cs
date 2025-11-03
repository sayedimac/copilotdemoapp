using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostalCodeLookup.Services;

namespace PostalCodeLookup.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IPostalCodeService _postalCodeService;

    public IndexModel(ILogger<IndexModel> logger, IPostalCodeService postalCodeService)
    {
        _logger = logger;
        _postalCodeService = postalCodeService;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnGetSearchAddressesAsync(string postalCode)
    {
        if (string.IsNullOrWhiteSpace(postalCode))
        {
            return new JsonResult(new List<string>());
        }

        // Validate postal code length and format (basic validation)
        if (postalCode.Length > 10)
        {
            _logger.LogWarning("Postal code exceeds maximum length: {PostalCode}", postalCode);
            return new JsonResult(new List<string>());
        }

        var addresses = await _postalCodeService.GetAddressesByPostalCodeAsync(postalCode);
        return new JsonResult(addresses);
    }
}
