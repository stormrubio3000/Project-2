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
    public class RaceController : ControllerBase
    {
        public CharacterRepository Repo { get; }

        public RaceController(CharacterRepository repo)
        {
            Repo = repo;
        }

        // GET: api/Race
        [HttpGet]
        public IEnumerable<Race> Get()
        {
            return Repo.GetAllRaces();
        }
    }
}
