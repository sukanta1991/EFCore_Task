using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCoreEF.BusinessLayer;
using MyCoreEF.DomainModels;

namespace MyCoreEF.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IBusiness _business;
        public EmployeeController(IBusiness business)
        {
            _business = business;
        }

        [HttpPost]

        public async Task<IActionResult> Post(Emp employee)
        {
            await _business.AddEmployee(employee);

            return NoContent();
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           var empDetails = await _business.GetEmployee(id);

            return Ok(empDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Empdet = await _business.GetEmplyees();
            return Ok(Empdet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Emp emp)
        {
            var updateEmp = await _business.UpdateEmployee(id, emp);
            return Ok(updateEmp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          var deletedEmp= await _business.DeleteEmployee(id);
            return Ok(deletedEmp);
        }
    }
}