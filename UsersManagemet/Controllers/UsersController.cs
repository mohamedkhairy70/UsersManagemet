using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.Services;

namespace UsersManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersRepository usersRepository;

        public UsersController(IUsersRepository _usersRepository)
        {
            this.usersRepository = _usersRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers() => Ok(usersRepository.GetUsers());


        [HttpGet("{Id}",Name = nameof(GetUserById))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public IActionResult GetUserById(int Id) => Ok(usersRepository.GetUserById(Id));


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult Add(User newUser)
        {
            if(newUser.Id < 1)
            {
                return BadRequest("Invalid Id");
            }
            usersRepository.Add(newUser);
            return CreatedAtAction(nameof(GetUserById),new { Id = newUser.Id },newUser);
        }



        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int Id)
        {
            try
            {
                usersRepository.DeleteUserById(Id);
            }
            catch
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
