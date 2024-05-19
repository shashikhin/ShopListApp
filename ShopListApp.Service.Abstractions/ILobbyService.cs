using ShopListApp.Domain.Models;

namespace ShopListApp.Service.Abstractions
{
    public interface ILobbyService
    {
        bool AddProductToLobby(int lobbyId, int productId);
        bool AddUserToLobby(int lobbyId, int userId);
        ICollection<User> GetLobbyUsers(int lobbyId);
        ICollection<Product> GetLobbyProducts(int lobbyId);
    }
}
