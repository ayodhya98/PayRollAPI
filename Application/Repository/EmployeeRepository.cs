using PayRoll.Application.Repository.IRepository;
using PayRoll.Core.Model;
using PayRoll.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private protected ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Employee> EditAsync(Employee entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _db.employees.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
