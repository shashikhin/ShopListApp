namespace ShopListApp.Domain.Models
{
    public class LobbyUser
    {
        public int UserId { get; set; }
        public int LobbyId { get; set; }
        public User User { get; set; }
        public Lobby Lobby { get; set; }
    }
}
