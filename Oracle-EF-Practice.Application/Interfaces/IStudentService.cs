using Oracle_EF_Practice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<STUDENT>> GetAllStudentsAsync();
    }
}
