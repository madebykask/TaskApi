using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TaskApi.Models;

namespace TaskApi.Controllers
{
    public class DHTasksController : ApiController
    {
        private TasksConnection db = new TasksConnection();

        // GET: DHTasks
        public IQueryable<DHTask> GetTasks()
        {
            return db.DHTasks;
        }

        // GET: api/DHTasks/5
        [ResponseType(typeof(DHTask))]
        public IHttpActionResult GetTask(int id)
        {
            DHTask task = db.DHTasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/DHTask/x
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, DHTask task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskId)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DHTask
        [ResponseType(typeof(DHTask))]
        public IHttpActionResult CreateTask(DHTask task)
        {
            var koll = task;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.DHTasks.Add(task);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                string error = e.Message;
            }
            

            return CreatedAtRoute("DefaultApi", new { id = task.TaskId }, task);
        }

        // DELETE: api/DHTask/id
        [ResponseType(typeof(DHTask))]
        public IHttpActionResult DeleteTask(int id)
        {
            DHTask task = db.DHTasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            db.DHTasks.Remove(task);
            db.SaveChanges();

            return Ok(task);
        }

    }
}
