namespace PokéCoin.Models
{
    public class PokemonListResult
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonResult> Results { get; set; }
        public PokemonDetail Details { get; set; }
    }
}
