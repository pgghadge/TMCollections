using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMCollections_Api.DTO.Address;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserAddresses(Guid userId)
        {
            var addresses = await _addressService.GetUserAddressesAsync(userId);
            return Ok(addresses);
        }

        [HttpGet("details/{addressId}")]
        public async Task<IActionResult> GetAddress(Guid addressId)
        {
            var address = await _addressService.GetAddressByIdAsync(addressId);
            return address == null ? NotFound() : Ok(address);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateAddress(Guid userId, [FromBody] CreateAddressDto dto)
        {
            await _addressService.CreateAddressAsync(userId, dto);
            return Ok(new { message = "Address created successfully" });
        }

        [HttpPut("{addressId}")]
        public async Task<IActionResult> UpdateAddress(Guid addressId, [FromBody] UpdateAddressDto dto)
        {
            await _addressService.UpdateAddressAsync(addressId, dto);
            return Ok(new { message = "Address updated successfully" });
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddress(Guid addressId)
        {
            await _addressService.DeleteAddressAsync(addressId);
            return Ok(new { message = "Address deleted successfully" });
        }

    }
}
