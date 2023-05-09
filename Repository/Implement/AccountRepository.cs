using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ThienAspWebApi.Models;
using ThienAspWebApi.Repository.Interface;
using ThienAspWebApi.ViewModels;

namespace ThienAspWebApi.Repository.Implement
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(IConfiguration configuration ,SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }
        public async Task<IdentityResult> RegisterAsync(RegisterModel registerModel)
        {
            var user = new AppUser
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email,
                UserName = registerModel.Email
            };
            return await _userManager.CreateAsync(user, registerModel.Password);
        }

        public async Task<string> LoginAsync(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);
            if (!result.Succeeded)
            {
                return string.Empty;
            }
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SECRETKEY_JWT"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience : _configuration["JWT:ValidAudience"],
                expires : DateTime.Now.AddMinutes(5),
                signingCredentials : new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature )
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}
