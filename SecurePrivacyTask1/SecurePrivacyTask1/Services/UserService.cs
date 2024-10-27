using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SecurePrivacyTask1.Models;

namespace SecurePrivacyTask1.Services
{
    /// <summary>
    /// Service for managing user data in a MongoDB database.
    /// </summary>
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="settings">MongoDB settings for database configuration.</param>
        /// <param name="client">MongoDB client for database operations.</param>
        public UserService(IOptions<MongoDbSettings> settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _users = database.GetCollection<User>(settings.Value.UserCollectionName);

            // Create compound index on LastName and Email
            var indexKeys = Builders<User>.IndexKeys.Combine(
                Builders<User>.IndexKeys.Ascending(u => u.LastName),
                Builders<User>.IndexKeys.Ascending(u => u.Email)
            );
            _users.Indexes.CreateOne(new CreateIndexModel<User>(indexKeys));
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A list of users.</returns>
        public async Task<List<User>> GetAllUsers() => await _users.Find(u => true).ToListAsync();

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>The created user.</returns>
        public async Task<User> CreateUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            user.CreatedAt = DateTime.UtcNow;

            await _users.InsertOneAsync(user);
            return user;
        }
    }
}
