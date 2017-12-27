using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProteinTrackerWebAPI.Models
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new List<User>();
        private static int nextId = 0;

        public void Add(User user)
        {
            user.UserId = nextId;
            nextId++;
            users.Add(user);
        }

        public ReadOnlyCollection<User> GetAll()
        {
            return users.AsReadOnly();
        }

        public User GetById(int Id)
        {
            var user = users.SingleOrDefault(u => u.UserId == Id);
            if (user == null) return null;

            return new User { Goal = user.Goal, Name = user.Name, UserId = user.UserId, Total = user.Total };
        }

        public void Save(User updateUser)
        {
            var originalUser = users.SingleOrDefault(u => u.UserId == updateUser.UserId);
            if (originalUser == null) return;

            originalUser.Name = updateUser.Name;
            originalUser.Total = updateUser.Total;
            originalUser.Goal = updateUser.Goal;
        }        
    }
}
