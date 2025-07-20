using TMCollections_Api.DTO.User;

namespace TMCollections_Api.Services_New.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserDto dto);
        Task<UserDto?> LoginAsync(LoginUserDto dto);
        Task<UserDto?> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, RegisterUserDto dto);
    }
}
