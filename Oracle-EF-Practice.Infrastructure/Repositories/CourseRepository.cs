using Oracle_EF_Practice.Domain.Entities;
using Oracle_EF_Practice.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IGenericContextRepository<Course> _courseContextRepository;

        public CourseRepository(IGenericContextRepository<Course> courseContextRepository)
        {
            _courseContextRepository = courseContextRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseContextRepository.GetAllAsync();
        }
    }
}
