using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersTasks.Models;
using UsersTasks.Models.Enums;
using System.Globalization;

namespace UsersTasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext db;
        public UserController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get(int page = 1, int size = 5)
        {

            if (db.Objectives.Count() == 0)
            {
                return NotFound();
            }
            return await db.Users
                .OrderByDescending(x => x.UserId)
                .Skip(((int)page - 1) * (int)size).Take((int)size)
                .ToListAsync();
        }


        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }


        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post(UserDTO userData)
        {
            if (userData == null)
            {
                return BadRequest();
            }

            var newUser = new User()
            {
                Surname = userData.Surname,
                Name = userData.Name,
                Status = Status.Active,
                CreatedTime = DateTime.Now
            };

            db.Users.Add(newUser);
            await db.SaveChangesAsync();
            return Ok(userData);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<User>> Put(int Id, UserDTO user)
        {
            var updateUser = db.Users.FirstOrDefault(i => i.UserId == Id);
            if(updateUser!=null)
            {
                updateUser.Name = user.Name;
                updateUser.Surname = user.Surname;
                updateUser.UpdatedTime = DateTime.Now;
                db.Update(updateUser);
            }
            return updateUser;
        }
        

     // DELETE api/users/5
     [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("add-task-to-exec")]
        public async Task<ActionResult> AddTaskToUser(int Id, ExecutorObjectiveDTO objectiveData)
        {
            var updateObjective = db.Objectives.FirstOrDefault(i => i.ObjectiveId == Id);
            if (updateObjective == null)
            {
                return BadRequest();
            }

            if (updateObjective != null)
            {
                updateObjective.ExecutorId = objectiveData.ExecutorId;
                updateObjective.UpdatedTime = DateTime.Now;
                db.Update(updateObjective);
            }
            return Ok(updateObjective);
        }

    }
}
