using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Departments {  get; }
        IEmployeeRepository Employee { get; }
        Task SaveAsync();
    }
}
