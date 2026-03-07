using GRTAssist.API.DTOs;

namespace GRTAssist.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(CreateUserDto userDto);
        Task<string> LoginAsync(string email, string password);
        Task<bool> ValidateTokenAsync(string token);
        Task<UserDto> GetCurrentUserAsync(string userId);
    }
}