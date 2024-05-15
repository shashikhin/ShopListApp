using ShopListApp.Domain.Models;

namespace ShopListApp.Abstractions
{
    public interface ILobbyRepository
    {
        Lobby GetLobby(int id);
        ICollection<Lobby> GetLobbys();
        bool CreateLobby(int userId);
        bool DeleteLobby(int id);
        bool UpdateLobby(Lobby lobby);
        bool AddUserToLobby(int id, int userId);
        bool AddProductToLobby(int id, int productId);
    }
}
