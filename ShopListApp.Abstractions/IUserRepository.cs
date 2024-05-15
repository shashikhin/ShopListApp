using ShopListApp.Domain.Models;

namespace ShopListApp.Abstractions
{
    public interface IUserRepository
    {
        User GetUser(int id);
        ICollection<User> GetUsers();
        bool CreateUser(User product);
        bool DeleteUser(int id);
        bool UpdateUser(User product);
    }
}