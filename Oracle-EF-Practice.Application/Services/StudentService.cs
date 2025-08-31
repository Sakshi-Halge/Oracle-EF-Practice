using Oracle_EF_Practice.Domain.Entities;
using Oracle_EF_Practice.Infrastructure.Interfaces;
using Oracle_EF_Practice.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<STUDENT>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
    }
}
