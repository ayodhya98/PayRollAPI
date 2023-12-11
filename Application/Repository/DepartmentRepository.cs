using PayRoll.Application.Repository.IRepository;
using PayRoll.Core.Model;
using PayRoll.DataAccess.Data;

namespace PayRoll.Application.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private protected ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Department> EditAsync(Department entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _db.Departments.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
