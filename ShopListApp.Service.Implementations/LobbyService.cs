using ShopListApp.Service.Abstractions;
using ShopListApp.Abstractions;
using ShopListApp.Domain.Models;

namespace ShopListApp.Service.Implementations
{
    public class LobbyService : ILobbyService
    {
        private readonly IProductRepository _productRepo;
        private readonly ILobbyRepository _lobbyRepo;

        public LobbyService(IProductRepository productRepository,
            ILobbyRepository lobbyRepository)
        {
            _productRepo = productRepository;
            _lobbyRepo = lobbyRepository;
        }
        public bool AddProductToLobby(int lobbyId, int productId)
        {
            return (_lobbyRepo.AddProductToLobby(lobbyId, productId));
        }

        public bool AddUserToLobby(int lobbyId, int userId)
        {
            return(_lobbyRepo.AddUserToLobby(lobbyId, userId));
        }

        public ICollection<Product> GetLobbyProducts(int lobbyId)
        {
            return (_lobbyRepo.GetLobbyProducts(lobbyId));
        }

        public ICollection<User> GetLobbyUsers(int lobbyId)
        {
            return(_lobbyRepo.GetLobbyUsers(lobbyId));
        }
    }
}