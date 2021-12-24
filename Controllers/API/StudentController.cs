using Microsoft.AspNetCore.Mvc;
using StudentDemo.DAL;
using StudentDemo.Models;

namespace StudentDemo.Controllers.API
{
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext context;
        public StudentController(AppDbContext _context)
        {
            context = _context;
        }

        [Route("api/[controller]/[action]")]
        public IActionResult GetStudents()
        {
            var data = context.students.ToList();
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetStudent(int id )
        {
            var data = context.students.Find(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            context.students.Add(student);
            context.SaveChanges();
            return Ok(student);
        }

        [HttpPut]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var data = context.students.Find(id);
            data.Name = student.Name;
            data.Age = student.Age;
            context.SaveChanges();
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var data = context.students.Find(id);
            context.students.Remove(data);
            context.SaveChanges();
            return NoContent();
        }
    }
}
