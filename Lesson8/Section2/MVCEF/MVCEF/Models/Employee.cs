using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEF.Models
{
    public class Employee
    {
        public int EmployeeId { get; private set; }
        public string Name { get; set; }

        public decimal Salary { get; set; }
        public string Designation { get; set; }

    }
}
