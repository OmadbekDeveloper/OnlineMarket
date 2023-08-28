//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using OnlineMarket.Models.User;
//using System.Threading.Tasks;

//namespace OnlineMarket.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize] // Ensure the user is authenticated
//    public class UserProfileController : ControllerBase
//    {
//        private readonly UserManager<User> _userManager;

//        public UserProfileController(UserManager<User> userManager)
//        {
//            _userManager = userManager;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetUserProfile()
//        {
//            var user = await _userManager.GetUserAsync(User);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            return Ok(user);
//        }

//        [HttpPut]
//        public async Task<IActionResult> UpdateUserProfile([FromBody] UserProfileUpdateModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var user = await _userManager.GetUserAsync(User);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            // Update user properties based on the model
//            user.FirstName = model.FirstName;
//            user.LastName = model.LastName;
//            user.Email = model.Email;

//            var result = await _userManager.UpdateAsync(user);
//            if (!result.Succeeded)
//            {
//                return BadRequest(result.Errors);
//            }

//            return Ok("User profile updated successfully.");
//        }
//    }
//}
