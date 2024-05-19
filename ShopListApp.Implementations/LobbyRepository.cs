using ShopListApp.Domain.Models;
using ShopListApp.Data.Context;
using ShopListApp.Abstractions;

namespace ShopListApp.Implementations
{
    public class LobbyRepository : ILobbyRepository
    {
        private readonly ApplicationContext _context;
        public LobbyRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool CreateLobby(int userId)
        {
            bool isSaved;

            User user = _context.Users.Where(p => p.Id == userId).FirstOrDefault();
            if (user == null) return false;

            Lobby lobby = new();

            _context.Lobbys.Add(lobby);
            isSaved = Save();

            if (isSaved)
            {
                LobbyUser lobbyUser = new()
                {
                    User = user,
                    Lobby = lobby
                };
                _context.LobbyUsers.Add(lobbyUser);
            }
            else
                return false;

            return Save();
        }

        public bool DeleteLobby(int lobbyId)
        {
            var _lobby = GetLobby(lobbyId);
            if (_lobby == null) return false;
            _context.Lobbys.Remove(_lobby);

            return Save();
        }

        public Lobby GetLobby(int id)
        {
            return _context.Lobbys.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Lobby> GetLobbys()
        {
            return _context.Lobbys.ToList();
        }

        public bool UpdateLobby(Lobby lobby)
        {
            _context.Update(lobby);
            return Save();
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool AddUserToLobby(int id, int userId)
        {
            var lobby = GetLobby(id);
            var user = _context.Users.Where(p => p.Id == userId).FirstOrDefault();

            if (lobby == null || user == null) return false;

            LobbyUser lobbyUser = new()
            {
                User = user,
                Lobby = lobby
            };

            _context.LobbyUsers.Add(lobbyUser);
            return Save();
        }

        public bool AddProductToLobby(int id, int productId)
        {
            var lobby = GetLobby(id);
            var product = _context.Products.Where(p => p.Id == productId).FirstOrDefault();

            if (lobby == null || product == null) return false;

            LobbyProduct lobbyProduct = new()
            {
                Lobby = lobby,
                Product = product
            };

            _context.LobbyProducts.Add(lobbyProduct);
            return Save();
        }

        public ICollection<User> GetLobbyUsers(int lobbyId)
        {
            var lobbyUsers = _context.LobbyUsers
                .Where(l => l.Lobby.Id == lobbyId)
                .Select(u  => u.User).ToList();
            return lobbyUsers;
        }

        public ICollection<Product> GetLobbyProducts(int lobbyId)
        {
            var lobbyProducts = _context.LobbyProducts
                .Where(l => l.Lobby.Id == lobbyId)
                .Select(p => p.Product).ToList();
            return lobbyProducts;
        }
    }
}