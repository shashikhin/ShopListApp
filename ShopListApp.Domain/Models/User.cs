namespace ShopListApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public ICollection<LobbyUser>? LobbyUsers { get; set; }
    }
}