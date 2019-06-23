using System;
using System.Collections.Generic;
using MyCoreEF.DataEntity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyCoreEF.DataAccessLayer
{
    public class DataAccess : IDataAccess
    {
        private readonly EmpDbContext _empDbContext;

        public DataAccess(EmpDbContext empDbContext)
        {
            _empDbContext = empDbContext;
        }
        
        public Task<Employee> GetEmployee(int id)
        {
          
             return  _empDbContext.Employees.FindAsync(id);
        }

        public Task<List<Employee>> GetEmplyees()
        {
            return _empDbContext.Employees.ToListAsync();
        }

        public Task<bool> AddEmployee(Employee employee)
        {
            try
            {
                var addemp = _empDbContext.Employees.Add(employee);
                _empDbContext.SaveChangesAsync();
            }
            catch
            {
                return Task.FromResult(false);
            }
                return Task.FromResult(true);
        }

        public Task<bool> UpdateEmployee(int id, Employee employee)
        {
            try
            {


                var updateEmp = _empDbContext.Employees.Find(id);
                updateEmp.Name = employee.Name;
                updateEmp.Salary = employee.Salary;
                updateEmp.Department = employee.Department;
                _empDbContext.SaveChangesAsync();
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var deletedEmp = _empDbContext.Employees.Find(id);
                _empDbContext.Employees.Remove(deletedEmp);
                _empDbContext.SaveChangesAsync();
            }
            catch
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
