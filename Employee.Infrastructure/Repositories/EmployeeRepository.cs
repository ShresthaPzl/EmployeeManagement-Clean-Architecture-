using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext _context) :base(_context)
        {

        }

        public async Task<IEnumerable<Employee>> GetEmployeeByLastName(string lastName)
        {
            return await _context.Employees.Where(x => x.LastName.Contains(lastName)).ToListAsync();
        }
    }
}
