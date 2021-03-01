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
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectiveController : ControllerBase
    {
        private readonly DatabaseContext db;
        public ObjectiveController(DatabaseContext context)
        {
            db = context;
         
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objective>>> Get(int page = 1, int size=5)
        {
            if (db.Objectives.Count() == 0)
            {
                return NotFound();
            }
            return await db.Objectives
                .OrderByDescending(x => x.ObjectiveId)
                .Skip(((int)page - 1) * (int)size).Take((int)size)
                .ToListAsync();
        }

        [HttpGet("/get-directors-tasks")]
        public async Task<ActionResult<Objective>> GetDirectorsTasks(int id)
        {
            //Objective objective = await db.Objectives.FirstOrDefaultAsync(x => x.DirectorId == id);
            var objectives = await db.Objectives.Where(x => x.DirectorId == id).ToListAsync();
            if (objectives == null)
                return NotFound();
            return new ObjectResult(objectives);
        }

        [HttpGet("/get-executioner-tasks")]
        public async Task<ActionResult<Objective>> GetExecutionerTasks(int id)
        {
            var objectives = await db.Objectives.Where(x => x.ExecutorId == id).ToListAsync();
            if (objectives == null)
                return NotFound();
            return new ObjectResult(objectives);
        }



        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objective>> Get(int id)
        {
            Objective objective = await db.Objectives.FirstOrDefaultAsync(x => x.ObjectiveId == id);
            if (objective == null)
                return NotFound();
            return new ObjectResult(objective);
        }
       
        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Objective>> Post(ObjectiveDTO objectiveData)
        {
            if (objectiveData == null)
            {
                return BadRequest();
            }

            var newObjective = new Objective()
            {
                Name = objectiveData.Name,
                Description = objectiveData.Description,
                StatusObjective = StatusTask.InProcess,
                CreatedTime = DateTime.Now,
                ExecutorId = objectiveData.ExecutorId,
                DirectorId = objectiveData.DirectorId
            };


            db.Objectives.Add(newObjective);
            await db.SaveChangesAsync();
            return Ok(objectiveData);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Objective>> Put(int Id, ObjectiveEditDTO updateObjective)
        {
            var newObjective = db.Objectives.FirstOrDefault(x => x.ObjectiveId == Id);

            if(newObjective != null)
            {
                newObjective.Name = updateObjective.Name;
                newObjective.Description = updateObjective.Description;
                newObjective.ExecutorId = updateObjective.ExecutorId;
                newObjective.UpdatedTime = DateTime.Now;
                db.SaveChanges();
            }
            return Ok(newObjective);

        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Objective>> Delete(int id)
        {
            Objective objective = db.Objectives.FirstOrDefault(x => x.ObjectiveId == id);
            if (objective == null)
            {
                return NotFound();
            }
            db.Objectives.Remove(objective);
            await db.SaveChangesAsync();
            return Ok(objective);
        }

    }
}
