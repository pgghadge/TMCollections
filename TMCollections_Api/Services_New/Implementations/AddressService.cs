using AutoMapper;
using TMCollections_Api.DTO.Address;
using TMCollections_Api.Models;
using TMCollections_Api.Services.Interfaces.Repositories;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Services_New.Implementations
{
    public class AddressService : IAddressService
    {
        
            private readonly IAddressRepository _addressRepo;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepo;

            public AddressService(IAddressRepository addressRepo, IMapper mapper, IUserRepository user)
            {
                _addressRepo = addressRepo;
                _mapper = mapper;
                _userRepo = user;
                
            }

            public async Task<List<AddressDto>> GetUserAddressesAsync(Guid userId)
            {
                var addresses = await _addressRepo.GetAllAsync();
                return addresses
                    .Where(a => a.UserId == userId)
                    .Select(a => _mapper.Map<AddressDto>(a))
                    .ToList();
            }

            public async Task<AddressDto?> GetAddressByIdAsync(Guid addressId)
            {
                var address = await _addressRepo.GetByIdAsync(addressId);
                return address == null ? null : _mapper.Map<AddressDto>(address);
            }

            public async Task CreateAddressAsync(Guid userId, CreateAddressDto dto)
            {
                var user = await _userRepo.GetByIdAsync(userId);
                    if (user == null)
                        throw new Exception("User does not exist.");


                var address = new Address
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    FullName = dto.FullName,
                    PhoneNumber = dto.PhoneNumber,
                    Street = dto.Street,
                    City = dto.City,
                    State = dto.State,
                    PostalCode = dto.PostalCode
                };

                
                await _addressRepo.AddAsync(address);
                await _addressRepo.SaveChangesAsync();
            }

            public async Task UpdateAddressAsync(Guid addressId, UpdateAddressDto dto)
            {
                var address = await _addressRepo.GetByIdAsync(addressId);
                if (address == null) throw new Exception("Address not found");

                address.FullName = dto.FullName;
                address.PhoneNumber = dto.PhoneNumber;
                address.Street = dto.Street;
                address.City = dto.City;
                address.State = dto.State;
                address.PostalCode = dto.PostalCode;

                _addressRepo.Update(address);
                await _addressRepo.SaveChangesAsync();
            }

            public async Task DeleteAddressAsync(Guid addressId)
            {
                var address = await _addressRepo.GetByIdAsync(addressId);
                if (address == null) throw new Exception("Address not found");

                _addressRepo.Delete(address);
                await _addressRepo.SaveChangesAsync();
            }
        }
}
