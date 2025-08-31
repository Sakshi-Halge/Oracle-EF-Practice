using Oracle_EF_Practice.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<STUDENT>> GetAllStudentsAsync();
    }
}
