using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MHefny_TaskDBContext context;
        public UserController(MHefny_TaskDBContext context)
        {
            this.context = context;

           

        }

        // GET: api/User All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await context.user.ToListAsync();
        }


        // GET: api/User By ID

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int ID)
        {
            var user = await context.user.FindAsync(ID);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }


        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            context.user.Add(User);
            await context.SaveChangesAsync();

            // return CreatedAtAction("GetUser", new { ID = User.Id }, User);
            return CreatedAtAction("GetUser", new { ID = User.ID });
        }


        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {

            User.ID = id;
            
            if (id != User.ID)
            {
                return BadRequest();
            }

            context.Entry(User).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var User = await context.user.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            context.user.Remove(User);
            await context.SaveChangesAsync();

            return User;
        }

    }

}