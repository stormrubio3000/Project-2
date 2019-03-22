using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANightsTaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UserRepository Repo { get; }

        public UsersController(UserRepository repo)
        {
            Repo = repo;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> Get()
        {
			return Repo.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUsers")]
        public Users Get(int id)
        {
            return Repo.GetUserById(id);
        }

        // POST: api/Users
        [HttpPost]
        [ProducesResponseType(typeof(Users), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post([FromBody, Bind("Name")] Users user)
        {
            Repo.CreateUser(user);
            Repo.Save();
        }
    }
}
