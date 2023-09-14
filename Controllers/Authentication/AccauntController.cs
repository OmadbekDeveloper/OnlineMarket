//namespace OnlineMarket.Controllers.Authentication
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//        private readonly UserManager<User> _userManager;
//        private readonly SignInManager<User> _signInManager;
//        private readonly IConfiguration _configuration;

//        public AccountController(
//            UserManager<User> userManager,
//            SignInManager<User> signInManager,
//            IConfiguration configuration)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _configuration = configuration;
//        }

//        [HttpPost("{register}")]
//        public async Task<IActionResult> Register([FromBody] RegisterModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var user = new User
//            {
//                UserName = model.Email,
//                Email = model.Email
//            };

//            var result = await _userManager.CreateAsync(user, model.Password);

//            if (!result.Succeeded)
//            {
//                return BadRequest(result.Errors);
//            }

//            return Ok("User registered successfully.");
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: true);

//            if (!result.Succeeded)
//            {
//                return BadRequest("Invalid login attempt.");
//            }

//            var user = await _userManager.FindByEmailAsync(model.Email);
//            return await GenerateJwtToken(user);
//        }

//        private async Task<IActionResult> GenerateJwtToken(User user)
//        {
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
//                new Claim(JwtRegisteredClaimNames.Email, user.Email),
//                // Add additional claims here as needed
//            };

//            var token = new JwtSecurityToken(
//                issuer: _configuration["Jwt:Issuer"],
//                audience: _configuration["Jwt:Audience"],
//                claims: claims,
//                expires: DateTime.UtcNow.AddHours(1),
//                signingCredentials: creds
//            );

//            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

//            return Ok(new { Token = tokenString });
//        }
//    }
//}
