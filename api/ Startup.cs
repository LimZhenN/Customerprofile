public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp",
                builder => builder
                    .WithOrigins("http://localhost:3000") // Your React app's URL
                    .AllowAnyMethod()                     // Allows all HTTP methods (GET, POST, PUT, DELETE, etc.)
                    .AllowAnyHeader()                     // Allows all headers (e.g., Authorization, Content-Type)
                    .AllowCredentials());                 // Allows credentials (cookies, authorization headers, etc.)
        });
    }

    // This method sets up the HTTP request pipeline, defining how the application responds to HTTP requests.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Enables the "AllowReactApp" CORS policy, which permits requests from the specified origin (React app).
        app.UseCors("AllowReactApp");
        // Adds routing middleware to the request pipeline, allowing endpoint routing to take place.
        app.UseRouting();
        // Configures the endpoints for the application, setting up routes for controllers.
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Maps routes for controllers to handle HTTP requests.
        });
    }
}