using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProteinTrackerWebAPI.Models
{
    public interface IUserRepository
    {
        void Add(User user);
        ReadOnlyCollection<User> GetAll();
        User GetById(int Id);
        void Save(User updateUser);
    }
}
