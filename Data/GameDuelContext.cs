using Microsoft.EntityFrameworkCore;
using GameDuel.API.Models;

namespace GameDuel.API.Data
{
    public class GameDuelContext : DbContext
    {
        public GameDuelContext(DbContextOptions<GameDuelContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Matchup> Matchups { get; set; }
    }
}