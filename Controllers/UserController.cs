using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public DBContext dbContext { get; set; }
        public UserController() {
            dbContext = new DBContext();
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return dbContext.Users.ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return dbContext.Users.FirstOrDefault(e => e.ID_User == id);
        }
        [HttpPost("check")]
        public User Check([FromBody] User user)
        {
            return dbContext.Users.FirstOrDefault(e => e.Username == user.Username && e.Password == user.Password);
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { ID_User = user.ID_User }, user);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            var entity = dbContext.Users.FirstOrDefault(e => e.ID_User == id);
            entity.Name = user.Name;
            entity.Password = user.Password;
            entity.SDT = user.SDT;
            entity.DiaChi = user.DiaChi;
            entity.Email = user.Email;
            entity.Coin = user.Coin;
            dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            dbContext.Remove(user);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}