namespace PokéCoin.Models
{
    public class PokemonResult
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public PokemonDetail Details { get; internal set; }
    }
}
