using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ANightsTaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        public CharacterRepository Repo { get; }

        public ClassController(CharacterRepository repo)
        {
            Repo = repo;
        }

        // GET: api/Class
        [HttpGet]
        public IEnumerable<Class> Get()
        {
            return Repo.GetAllClasses();
        }

        // POST: api/Class
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Class/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
