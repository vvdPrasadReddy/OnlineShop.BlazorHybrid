using Microsoft.AspNetCore.Identity;
using OnlineShop.API.Data;
using OnlineShop.API.Helpers;
using OnlineShop.API.Models;
using OnlineShop.API.Shared.ViewModels;
using DbModels = OnlineShop.API.Models;

namespace OnlineShop.API.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Get all countries
        /// </summary>
        /// <returns></returns>
        List<DbModels.Country> GetCounties();

        /// <summary>
        /// Get all states by country id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        List<DbModels.State> GetStates(int countryId);

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        bool Register(UserDetails register);

        /// <summary>
        /// login a user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<AuthenticationResponseDTO> Login(LoginModel login);
    }

    public class UserService: IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly OnlineShopContext _context;
        private readonly ITokenHelper _jwtService;

        public UserService(OnlineShopContext context, UserManager<IdentityUser> userManager, ITokenHelper jwtService)
        {
            _context = context;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        ///<see cref="IUserService.GetCounties()"/>
        public List<DbModels.Country> GetCounties()
        {
            return _context.Countries.ToList();
        } 

        ///<see cref="IUserService.GetStates(int)"/>
        public List<DbModels.State> GetStates(int countryId)
        {
            return _context.States.Where(x=>x.CountryId==countryId).ToList();
        }

        ///<see cref="IUserService.Register(UserDetails)"/>
        public bool Register(UserDetails register)
        {
            var user = new IdentityUser
            {
                UserName = register.Email,
                Email = register.Email
            };

            var result = _userManager.CreateAsync(user, register.Password).Result;

            if (result.Succeeded)
            {
                var address = new Address
                {
                    CountryId = register.CountryId.Value,
                    StateId = register.StateId.Value,
                    //MobileNumber = register.MobileNumber,
                    UserId = user.Id
                };

                _context.Addresses.Add(address);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        ///<see cref="IUserService.Login(LoginModel)"/>
        public async Task<AuthenticationResponseDTO> Login(LoginModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            AuthenticationResponseDTO response = new AuthenticationResponseDTO();
            if (user != null)
            {
                bool result = await _userManager.CheckPasswordAsync(user, login.Password);
                if (result)
                {
                    response = _jwtService.CreateToken(user);
                }
                return response;
            }
            return null;
        }
    }
}
