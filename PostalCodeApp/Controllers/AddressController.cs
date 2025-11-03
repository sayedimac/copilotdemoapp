using Microsoft.AspNetCore.Mvc;
using PostalCodeApp.Services;

namespace PostalCodeApp.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search(string postalCode)
        {
            var addresses = await _addressRepository.SearchByPostalCodeAsync(postalCode);
            return Json(addresses);
        }
    }
}
