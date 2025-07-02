using RestSharp;
using Newtonsoft.Json;
using SimplePokedex.Models;

namespace SimplePokedex.Services
{
    public class PokeApiService
    {
        private readonly RestClient _client;
        private readonly RestClientOptions _options;

        public PokeApiService()
        {
            _options = new RestClientOptions("https://pokeapi.co/api/v2/")
            {
                MaxTimeout = 10000 // 10 seconds timeout
            };
            _client = new RestClient(_options);
        }

        public async Task<Pokemon> GetPokemonAsync(string nameOrId)
        {
            try
            {
                var request = new RestRequest($"pokemon/{nameOrId.ToLower().Replace(" ", "-")}");
                var response = await _client.ExecuteAsync(request);
                
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<Pokemon>(response.Content);
                }
                
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Item> GetItemAsync(string name)
        {
            try
            {
                var request = new RestRequest($"item/{name.ToLower().Replace(" ", "-")}");
                var response = await _client.ExecuteAsync(request);
                
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<Item>(response.Content);
                }
                
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Move> GetMoveAsync(string name)
        {
            try
            {
                var request = new RestRequest($"move/{name.ToLower().Replace(" ", "-")}");
                var response = await _client.ExecuteAsync(request);
                
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<Move>(response.Content);
                }
                
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
