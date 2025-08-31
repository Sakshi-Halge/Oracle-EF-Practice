using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle_EF_Practice.Models.Entities;
using Oracle_EF_Practice.Services.Interfaces;

namespace Oracle_EF_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<STUDENT>>> GetAppStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }
    }
}
