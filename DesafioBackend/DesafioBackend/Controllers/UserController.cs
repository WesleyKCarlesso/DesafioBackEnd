using DesafioBackend.Models;
using DesafioBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Create(string Name, int Age, string street, int number, string city, string state)
        {
            var user = new User() { Name = Name.Trim(), Age = Age };
            var address = new Address() { Street = street.Trim(), Number = number, City = city.Trim(), State = state.Trim() };

            user.Address= address;

            _userService.Create(user);

            return Ok();
        }

        [HttpGet("all")]
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
            var user = _userService.GetById(id.Trim());

            return user;
        }

        [HttpGet("filters")]
        public ActionResult<List<User>> GetAllByFilters(string? Name, string? Street)
        {
            var users = _userService.GetAll();

            if (Name != null)
            {
                users = users.Where(x => x.Name.ToLower().Contains(Name.Trim().ToLower())).ToList();
            }

            if (Street != null)
            {
                users = users.Where(x => x.Address.Street.ToLower().Contains(Street.Trim().ToLower())).ToList();
            }

            if (users is null)
            {
                return NotFound();
            }

            if ((Name == null && Street == null)) 
                return new List<User>();

            return users;
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, string? Name, int? Age, string? Street, int? Number, string? City, string? State)
        {
            var user = _userService.GetById(id.Trim());

            if (user is null)
            {
                return NotFound();
            }

            user.Name = Name?.Trim() ?? user.Name;
            user.Age = Age.HasValue ? Age.Value : user.Age;
            user.Address.Street = Street?.Trim() ?? user.Address.Street;
            user.Address.City = City?.Trim() ?? user.Address.City;
            user.Address.State = State?.Trim() ?? user.Address.State;
            user.Address.Number = Number.HasValue ? Number.Value : user.Address.Number;

            _userService.Update(id, user);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            _userService.Delete(id.Trim());

            return Ok();
        }
    }
}
