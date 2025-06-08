
namespace ams.service.services;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}