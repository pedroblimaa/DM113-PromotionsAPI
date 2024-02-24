using MongoDB.Driver;
using PromoAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddScoped<PromotionService>();
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
    {

        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var connectionString = builder.Configuration.GetValue<string>("MongoDB:ConnectionString");
        Console.WriteLine($"MongoDB connection string: {connectionString}");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ApplicationException("MongoDB connection string is missing or empty.");
        }

        try
        {
            return new MongoClient(connectionString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to MongoDB: {ex.Message}");
            throw;
        }
    }
);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();
