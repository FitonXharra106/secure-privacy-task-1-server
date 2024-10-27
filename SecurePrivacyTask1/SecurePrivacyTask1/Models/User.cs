namespace SecurePrivacyTask1.Models
{
    /// <summary>
    /// Represents a user in the application.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has given consent for data collection.
        /// This field is essential for GDPR compliance.
        /// </summary>
        public bool ConsentGiven { get; set; } // GDPR consent field

        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
