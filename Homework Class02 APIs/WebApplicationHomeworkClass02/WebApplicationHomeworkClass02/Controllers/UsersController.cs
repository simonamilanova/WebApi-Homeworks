using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationHomeworkClass02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private List<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName = "User1",
                LastName = "UserLastName1",
                Age = 20
            },
            
            new User()
            {
                Id = 2,
                FirstName = "User2",
                LastName = "UserLastName2",
                Age = 17
            },
            
            new User()
            {
                Id = 3,
                FirstName = "User3",
                LastName = "UserLastName3",
                Age = 29
            }
        };

        [HttpGet("getAll")]
        public List<User> GetAllUsers()
        {
            return users;
        }

        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("adultUser/{id}")]
        public ActionResult<string> CheckUserAge(int id)
        {
            if(users.SingleOrDefault(x => x.Id == id).Age >= 18)
            {
                return "This user is an adult.";
            }

            return StatusCode(StatusCodes.Status404NotFound, new { message = "This user is not an adult."});


        }
    }
}
