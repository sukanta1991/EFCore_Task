using System;
using System.Collections.Generic;
using MyCoreEF.DataAccessLayer;
using MyCoreEF.DomainModels;
using System.Linq;
using MyCoreEF.DataEntity;
using System.Threading.Tasks;

namespace MyCoreEF.BusinessLayer
{
    public class Business : IBusiness
    {
        private readonly IDataAccess _dataAccess;

        public Business(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<bool> AddEmployee(Emp emp)
        {
           var addEmployee = new Employee
            {
                Name = emp.Name, Salary = emp.Salary, Department = emp.Department
            };
           return  _dataAccess.AddEmployee(addEmployee);
        }

        public Task<bool> DeleteEmployee(int id)
        {
            var  returnVal = _dataAccess.DeleteEmployee(id);
            return returnVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Emp> GetEmployee(int id)
        {
            var getEmp = _dataAccess.GetEmployee(id).Result;
            var mapToEmp = new Emp
            {
                Name = getEmp.Name,
                Salary = getEmp.Salary,
                Department = getEmp.Department,
                SalaryCategory = getEmp.Salary > 50000 ? HelperConstants.HighIncome : HelperConstants.LowIncome
            };

            return Task.FromResult(mapToEmp);
        }

        public Task<List<Emp>> GetEmplyees()
        {
            var listEmp = _dataAccess.GetEmplyees().Result;
            var mapToEmp = listEmp.Select(x => new Emp
            {
                Name = x.Name,
                Salary = x.Salary,
                Department = x.Department,
                SalaryCategory= x.Salary>50000? HelperConstants.HighIncome : HelperConstants.LowIncome
            }).ToList();

            return Task.FromResult(mapToEmp);


        }

        public Task<bool> UpdateEmployee(int id, Emp emp)
        {
            var updateEmp = new Employee
                {


                    Name = emp.Name,
                    Salary = emp.Salary,
                    Department = emp.Department
                };
            var returnVal = _dataAccess.UpdateEmployee(id, updateEmp);
            return returnVal;
        }
    }
}
