using DesafioBackend.Models;
using DesafioBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService usersService)
        {
            _userService = usersService;
        }

        [HttpPost]
        public ActionResult Create(User newUser)
        {
            _userService.Create(newUser);

            return Ok();
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            var users = _userService.GetAll();
            if (users is null)
            {
                return NotFound();
            }

            return users;
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<User> GetById(string id)
        {
            var user = _userService.GetById(id);

            return user;
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, User newUser)
        {
            var user = _userService.GetById(id);
            if (user is null)
            {
                return NotFound();
            }

            newUser.Id = user.Id;
            _userService.Update(id, newUser);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            _userService.Delete(id);

            return Ok();
        }
    }
}
