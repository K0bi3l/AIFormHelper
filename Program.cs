using AIFormHelper.Services;
using AIFormHelper.Models;
public class Program
{
    public static void Main(string[] args)
    {
        // Create a new web application builder
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddUserSecrets<Program>();

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddHttpClient<ChatService>();
        builder.Services.AddSingleton<ChatService>();
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();

            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors();
        app.MapControllers();

        app.MapFallbackToFile("index.html");

        app.Run();
    }
}
