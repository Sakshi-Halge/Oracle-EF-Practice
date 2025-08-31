using Oracle_EF_Practice.Domain.Entities;
using Oracle_EF_Practice.Infrastructure.DBContext;
using Oracle_EF_Practice.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IGenericContextRepository<STUDENT> _studentContextRepository;

        public StudentRepository(AppDbContext appDbContext, IGenericContextRepository<STUDENT> studentContextRepository)
        {
            _appDbContext = appDbContext;
            _studentContextRepository = studentContextRepository;
        }


        public async Task<IEnumerable<STUDENT>> GetAllStudentsAsync()
        {
           return await _studentContextRepository.GetAllAsync();
        }
    }
}
