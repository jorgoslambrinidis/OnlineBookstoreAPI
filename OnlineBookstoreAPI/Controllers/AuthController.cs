namespace OnlineBookstoreAPI.API.Controllers
{
    using OnlineBookstoreAPI.DTOs;
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using OnlineBookstoreAPI.DTOs;
    using OnlineBookstoreAPI.Controllers;

    public class AuthController : BaseApiController<AuthController>
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AuthController(
            IAuthService authService,
            IConfiguration configuration,
            ITokenService tokenService)
        {
            _authService = authService;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerModel)
        {
            registerModel.Username = registerModel.Username.ToLower();

            if (await _authService.UserExists(registerModel.Username))
            {
                return BadRequest("Username already exists!");
            }

            var userToCreate = new User
            {
                Address = registerModel.Address,
                City = registerModel.City,
                Country = registerModel.Country,
                UserCreated = DateTime.Now,
                Description = registerModel.Description,
                Email = registerModel.Email,
                IsAdmin = false,
                Phone = registerModel.Phone,
                Username = registerModel.Username.ToLower()
            };

            var createdUser = await _authService.Register(userToCreate, registerModel.Password);

            if (createdUser != null)
            {
                Logger.LogInformation("Created new user!");
            }

            return new UserDTO
            {
                Username = createdUser.Username,
                Token = _tokenService.CreateToken(userToCreate)
            };
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginModel)
        {
            bool admin = false;

            // check if we have a user stored in our db
            var getUser = await _authService.Login(loginModel.Username, loginModel.Password);

            if (getUser == null)
            {
                return Unauthorized();
            }

            if (getUser.IsAdmin == true)
            {
                admin = true;
            }

            // our token it's going to contain 2 claims (users id/users username)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, getUser.Id.ToString()),
                new Claim(ClaimTypes.Name, getUser.Username)
            };

            // check if the tokens are valid, when it comes back the server needs to sign this token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            // use the key as part of signing credential, encrypting this key with hashing algorithm
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // token creation -> token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),         // passing claims as subject
                Expires = DateTime.Now.AddDays(1),            // give an expire date of 24h
                SigningCredentials = credentials              // passing signing credentials
            };

            // create a token handler - needed to create the token based on tokenDescriptor
            var tokenHandler = new JwtSecurityTokenHandler();

            // pass the tokenDescriptor via tokenHandler in the token variable
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // use the token variable to write the token - in the response that we send back to the client
            return new UserDTO
            {
                Username = getUser.Username,
                Token = _tokenService.CreateToken(getUser)
            };

            // we can check the created token via postman on
            // http://localhost:5000/api/auth/login
        }
    }
}
