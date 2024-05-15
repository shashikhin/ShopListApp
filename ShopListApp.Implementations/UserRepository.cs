using ShopListApp.Domain.Models;
using ShopListApp.Data.Context;
using ShopListApp.Abstractions;

namespace ShopListApp.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool DeleteUser(int userId)
        {
            var _user = GetUser(userId);
            if (_user == null) return false;
            _context.Users.Remove(_user);

            return Save();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }
        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
