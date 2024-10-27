using MongoDB.Driver;
using SecurePrivacyTask1;
using SecurePrivacyTask1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// <summary>Adds MongoDB settings and services to the dependency injection container.</summary>
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString")));

// <summary>Registers the UserService for handling user-related operations.</summary>
builder.Services.AddScoped<UserService>();

// Add CORS services
// <summary>Adds CORS policy to allow requests from any origin.</summary>
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Allow any origin
                   .AllowAnyMethod() // Allow any HTTP method (GET, POST, etc.)
                   .AllowAnyHeader(); // Allow any header
        });
});

// Add controllers and Swagger
builder.Services.AddControllers(); // <summary>Adds MVC controllers to the service collection.</summary>
builder.Services.AddEndpointsApiExplorer(); // <summary>Enables endpoint exploration for Swagger.</summary>
builder.Services.AddSwaggerGen(); // <summary>Adds Swagger generation services to the application.</summary>

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // <summary>Redirects HTTP requests to HTTPS.</summary>

// Use CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization(); // <summary>Enables authorization middleware.</summary>
app.MapControllers(); // <summary>Maps controllers to the request pipeline.</summary>
app.Run(); // <summary>Runs the application.</summary>
