namespace MovieDB.Models
{
    public class MovieListResponse
    {
        public int page { get; set; }
        public List<MovieItem> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }
}
