using Microsoft.AspNetCore.Mvc;
using SecurePrivacyTask1.Models;
using SecurePrivacyTask1.Services;

namespace SecurePrivacyTask1.Controllers
{
    /// <summary>
    /// Controller for handling user-related API requests.
    /// </summary>
    [ApiController] // Indicates that this class is an API controller
    [Route("api/[controller]")] // Route prefix for the controller
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService; // User service for handling user operations

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The user service to be injected.</param>
        public UsersController(UserService userService)
        {
            _userService = userService; // Assign the injected user service to the private field
        }

        /// <summary>
        /// Gets all users from the database.
        /// </summary>
        /// <returns>A list of users.</returns>
        // GET api/users
        [HttpGet] // Indicates this method responds to HTTP GET requests
        public async Task<ActionResult<List<User>>> Get() => await _userService.GetAllUsers();

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="user">The user information to create.</param>
        /// <returns>The created user.</returns>
        // POST api/users
        [HttpPost] // Indicates this method responds to HTTP POST requests
        public async Task<ActionResult<User>> Create(User user)
        {
            // Check if consent is given for data collection
            if (!user.ConsentGiven)
                return BadRequest("Consent is required for data collection."); // Return bad request if consent is not given

            var createdUser = await _userService.CreateUser(user); // Call service to create the user
            // Return a response indicating that the user has been created
            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }
    }
}
