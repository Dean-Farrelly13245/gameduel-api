using Microsoft.EntityFrameworkCore;
using GameDuel.API.Data;

namespace GameDuel.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<GameDuelContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("GameDuelDb")));

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GameDuelContext>();
                await DataSeeder.SeedGames(context);
            }

            await app.RunAsync();
        }
    }
}