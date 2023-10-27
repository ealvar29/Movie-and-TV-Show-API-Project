namespace MovieDB.Models
{
    public class MovieItem
    {
        public string imagePath { get ; set; }
        public List<int> genreIds { get; set; }
        public int movieId { get; set; }
        public string movieTitle { get; set; }
        public string overview { get; set; }
        public decimal vote_average { get; set; }
        public int vote_count { get; set;}
    }
}
