using ShopListApp.Domain.Models;

namespace ShopListApp.Service.Abstractions
{
    public interface ILobbyService
    {
        bool AddProductToLobby(int lobbyId, int productId);
    }
}
