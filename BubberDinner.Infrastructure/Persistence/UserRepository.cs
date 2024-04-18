using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(user => user.Email == email);
        }
    }
}