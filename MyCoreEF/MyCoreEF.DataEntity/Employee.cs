using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCoreEF.DataEntity
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}
