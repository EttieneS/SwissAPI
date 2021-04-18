using SwissAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.SQLite;
using Microsoft.AspNetCore.Mvc;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;

namespace SwissAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TeacherController : ApiController
    {
        private readonly SchoolDbContext _context;

        public TeacherController() : base() 
        {
            using (SchoolDbContext context = new SchoolDbContext())
            {
                _context = context;
            }
        }

        public async Task<IHttpActionResult> GetTeachersList()
        {
            using (SchoolDbContext context = new SchoolDbContext())
            {
                return Json(await context.Teacher.ToListAsync());
            }

        }

        public async Task<ActionResult<Teacher>> Create(Teacher teacher)
        {
            using (var context = new SchoolDbContext())
            {
                context.Teacher.Add(teacher);
                await context.SaveChangesAsync();
            }

            return teacher; 
        }
        
        public IHttpActionResult DeleteTeacher(int id)
        {
            if (id < 0)
            {
                return BadRequest("Not a valid student id.");
            }

            using (var context = new SchoolDbContext())
            {
                var teacher = context.Teacher
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
                context.Teacher.Remove(teacher);
                context.SaveChanges();
            }
            return Ok();
        }


    }
}
