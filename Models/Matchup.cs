namespace GameDuel.API.Models
{
    public class Matchup
    {
        public int Id { get; set; }
        public int GameAId { get; set; }
        public int GameBId { get; set; }
        public int? WinnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? VotedAt { get; set; }
    }
}