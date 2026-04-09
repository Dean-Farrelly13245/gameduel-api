namespace GameDuel.API.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public int ReleaseYear { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}