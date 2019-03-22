using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANightsTale.DataAccess;
using ANightsTale.DataAccess.Repos;
using ANightsTale.Library;
using ANightsTale.Library.Interfaces;
using ANightsTaleAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ANightsTaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public SignInManager<IdentityUser> SignInManager { get; }
        public UserRepository Repo { get; }

        public UsersController(SignInManager<IdentityUser> signInManager,
            AuthDbContext dbContext, UserRepository repo)
        {
            SignInManager = signInManager;
            Repo = repo;
            dbContext.Database.EnsureCreated();
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<ANightsTale.Library.Users> Get()
        {
			return Repo.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUsers")]
        public ANightsTale.Library.Users Get(int id)
        {
            return Repo.GetUserById(id);
        }

        // POST: api/Users
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ANightsTale.Library.Users), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync(Register register,
            [FromServices] RoleManager<IdentityRole> roleManager,
            [FromServices] UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser(register.Username);

            IdentityResult result = await userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded) // e.g. did not meet password policy
            {
                return BadRequest(result);
            }

            if (register.Permission == 0)
            {
                // make sure admin role exists
                if (!await roleManager.RoleExistsAsync("admin"))
                {
                    var role = new IdentityRole("admin");
                    var result2 = await roleManager.CreateAsync(role);
                    if (!result2.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "failed to create admin role");
                    }
                }

                // add user to admin role
                var result3 = await userManager.AddToRoleAsync(user, "admin");
                if (!result3.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "failed to add user to admin role");
                }
            }

            await SignInManager.SignInAsync(user, false);


            var newUser = new ANightsTale.Library.Users
            {
                Username = register.Username,
                Password = register.Password,
                Email = register.Email,
                Permission = register.Permission
            };

            Repo.CreateUser(newUser);
            Repo.Save();

            return NoContent();
        }
    }
}
