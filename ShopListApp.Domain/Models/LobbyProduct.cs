namespace ShopListApp.Domain.Models
{
    public class LobbyProduct
    {
        public int LobbyId { get; set; }
        public int ProductId { get; set; }
        public Lobby Lobby { get; set; }
        public Product Product { get; set; }
    }
}
