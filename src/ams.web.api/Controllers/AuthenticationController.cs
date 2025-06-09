namespace ams.web.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IJwtService _jwtService, IUserService _userService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest login)
    {
        var user = await _userService.GetUserByEmailAsync(login.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        var token = _jwtService.GenerateToken(user);
        return Ok(new { token });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        if (await _userService.GetUserByEmailAsync(request.Email, false) != null)
        {
            return BadRequest(new { message = "Email already exists" });
        }

        var newUser = new UserDto
        {
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            CreatedAt = DateTimeOffset.UtcNow
        };

        await _userService.AddUserAsync(newUser);
        return Ok(new { message = "Registration successful" });
    }

}
