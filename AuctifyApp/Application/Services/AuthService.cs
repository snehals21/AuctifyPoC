using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        private readonly IOAuthProvider _oauthProvider;

        public AuthService(IUserRepository userRepository, IJwtTokenProvider jwtTokenProvider, IOAuthProvider oauthProvider)
        {
            _userRepository = userRepository;
            _jwtTokenProvider = jwtTokenProvider;
            _oauthProvider = oauthProvider;
        }

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }
            return _jwtTokenProvider.GenerateToken(user);
        }

        public async Task<string> AuthenticateWithOAuthAsync(string provider, string token)
        {
            var userInfo = await _oauthProvider.GetUserInfoAsync(provider, token);
            var user = await _userRepository.GetByEmailAsync(userInfo.Email);

            if (user == null)
            {
                user = new User { Email = userInfo.Email, Role = "User" };
                await _userRepository.AddAsync(user);
            }

            return _jwtTokenProvider.GenerateToken(user);
        }
    }
}
