using MovieDB.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieDB.Service
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MovieService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            // Get the API key from configuration
            string apiKey = configuration["MovieDbApi:ApiKey"];

            // Add the API key as a query parameter
            _httpClient.DefaultRequestHeaders.Add("api_key", apiKey);
        }


        public async Task<MovieListResponse> GetPopularMovies()
        {
            string apiKey = _configuration.GetSection("MovieDbApi:ApiKey").Value;

            var response = await _httpClient.GetAsync($"discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc&api_key={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var movieList = Newtonsoft.Json.JsonConvert.DeserializeObject<MovieListResponse>(content);
                return movieList;
            }
            else
            {
                // Handle the error
                throw new Exception($"Failed to fetch data. Status code: {response.StatusCode}");
            }
        }
    }

}
