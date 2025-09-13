using Microsoft.AspNetCore.Mvc;
using Oracle_EF_Practice.Application.Interfaces;
using Oracle_EF_Practice.Application.Services;
using Oracle_EF_Practice.Domain.Entities;

namespace Oracle_EF_Practice.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<Course>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

    }
}
