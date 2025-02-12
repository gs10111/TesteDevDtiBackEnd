using Microsoft.AspNetCore.Mvc;
using SistemaNotasFrequencia.Models;
using SistemaNotasFrequencia.Services;

namespace SistemaNotasFrequenciaControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student is null");
            }
            await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
        }

        
        [HttpGet("overview")]
        public async Task<ActionResult> GetOverview()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var overview = _studentService.GetOverview(students);
            return Ok(overview);
        }
    }
}
