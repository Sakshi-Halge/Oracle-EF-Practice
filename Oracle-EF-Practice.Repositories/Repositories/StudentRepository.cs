using Oracle_EF_Practice.Models.Entities;
using Oracle_EF_Practice.Repositories.DBContext;
using Oracle_EF_Practice.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Repositories.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IGenericContextRepository<Student> _studentContextRepository;

        public StudentRepository(AppDbContext appDbContext, IGenericContextRepository<Student> studentContextRepository)
        {
            _appDbContext = appDbContext;
            _studentContextRepository = studentContextRepository;
        }


        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
           return await _studentContextRepository.GetAllAsync();
        }
    }
}
