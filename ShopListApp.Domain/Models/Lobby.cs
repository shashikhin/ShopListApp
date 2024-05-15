namespace ShopListApp.Domain.Models
{
    public class Lobby
    {
        public int Id { get; set; }
        public ICollection<LobbyUser>? LobbyUsers { get; set; }
        public ICollection<LobbyProduct>? LobbyProducts { get; set; }
    }
}