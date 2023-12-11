using PayRoll.Application.Repository.IRepository;
using PayRoll.Core.Model;
using PayRoll.DataAccess.Data;
using PayRoll.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Departments = new DepartmentRepository(_db);

        }
        public IDepartmentRepository Departments { get; private set; }
        public IEmployeeRepository Employee { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
