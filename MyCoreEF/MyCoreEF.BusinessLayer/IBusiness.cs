using MyCoreEF.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCoreEF.BusinessLayer
{
    public interface IBusiness
    {

        Task<List<Emp>> GetEmplyees();

        Task<bool> AddEmployee(Emp emp);

        Task<Emp> GetEmployee(int id);

        Task<bool> UpdateEmployee(int id, Emp emp);
        Task<bool> DeleteEmployee(int id);
    }
}
