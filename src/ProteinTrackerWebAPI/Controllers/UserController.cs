using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProteinTrackerWebAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProteinTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private UserRepository repo = new UserRepository();

        //public int AddProtein(int amount, int userId)  
        // api/user/50
        //public int Put(int id, [FromBody]int amount) // the amount is going to be in the Body, so we're going to use that FromBody (i.e., the payload for our data that we're going to send)
        //{
        //    var user = repo.GetById(id);
        //    if (user == null) return -1;
        //    user.Total += amount;
        //    repo.Save(user);
        //    return user.Total;            
        //}

        //public int AddUser(string name, int goal) FromBody: it's going to make it so that this request is not going to be passed in as parameter on the actual URL, 
        //instead it's going to expect to be in the body of this Post.
        [HttpPost("")]
        public IActionResult AddUser([FromBody]CreateUserRequest request)
        {
            var user = new User { Goal = request.Goal, Name = request.Name, Total = 0 };
            repo.Add(user);
            //return user.UserId;
            return View(user);
        }

        // GET: <controller>
        public IActionResult Index()
        {
            var data = repo.GetAll();
            return View(data);
        }

        //public IEnumerable<User> Get()
        //{
        //    // using the User Repository
        //    return new List<User>(repo.GetAll());
        //}

        public class CreateUserRequest
        {
            public string Name { get; set; }
            public int Goal { get; set; }
        }

    }
}
