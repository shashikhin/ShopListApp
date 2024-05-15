using ShopListApp.Service.Abstractions;
using ShopListApp.Abstractions;

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
            var lobby = _lobbyRepo.GetLobby(lobbyId);
            var product = _productRepo.GetProduct(productId);

            if (product == null || lobby == null) return false;

         /*   if (lobby.Products == null)
                lobby.Products = [product];
            else
                lobby.Products.Add(product);*/

            return (_lobbyRepo.UpdateLobby(lobby));
        }

        public bool AddUserToLobby(int lobbyId, int userId)
        {
            return(_lobbyRepo.AddUserToLobby(lobbyId, userId));
        }
    }
}