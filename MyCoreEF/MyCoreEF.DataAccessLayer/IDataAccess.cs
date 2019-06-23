using MyCoreEF.DataEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCoreEF.DataAccessLayer
{
    public interface IDataAccess
    {
       Task<List<Employee>> GetEmplyees();

        Task<bool> AddEmployee(Employee employee);

        Task<Employee> GetEmployee(int id);

        Task<bool> UpdateEmployee(int id,Employee employee);

        Task<bool> DeleteEmployee(int id);
        
  
        
    }
}
