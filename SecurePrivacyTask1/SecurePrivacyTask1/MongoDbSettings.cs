namespace SecurePrivacyTask1
{
    /// <summary>
    /// Represents the settings required to connect to a MongoDB database.
    /// </summary>
    public class MongoDbSettings
    {
        /// <summary>
        /// Gets or sets the connection string for the MongoDB server.
        /// This string contains information about the server's address, port, 
        /// and any required authentication credentials.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use on the MongoDB server.
        /// This database will hold collections of data relevant to the application.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the collection that will store user documents 
        /// within the specified database.
        /// </summary>
        public string UserCollectionName { get; set; }
    }
}
