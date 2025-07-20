using AutoMapper;
using Org.BouncyCastle.Crypto.Generators;
using TMCollections_Api.DTO.User;
using TMCollections_Api.Models;
using TMCollections_Api.Services.Interfaces.Repositories;
using TMCollections_Api.Services_New.Interfaces;


// ... rest of the file remains unchanged ...
namespace TMCollections_Api.Services_New.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _repo.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> LoginAsync(LoginUserDto dto)
        {
            var user = await _repo.GetByEmailAsync(dto.Email);
            if (user == null || user.Password != dto.Password )
            {              
                return null;
            }
            return _mapper.Map<UserDto?>(user);
        }

        public async Task RegisterAsync(RegisterUserDto dto)
        {
            var existsingUser =await  _repo.GetByEmailAsync(dto.Email);
            if (existsingUser != null)
            {
                throw new Exception("User with this email already exists");
            }

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role.ToString(), // Assuming Role is a string in User model
            };

            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, RegisterUserDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) throw new Exception("Not found");

            user.FullName = dto.FullName; 
            user.Email = dto.Email;
            user.Password = dto.Password;
            _repo.Update(user);
            await _repo.SaveChangesAsync();
        }
    }
}
