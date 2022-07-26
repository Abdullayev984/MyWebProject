using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.Entities
{
    public class Employee
    {[Key]
        public int EmpId { get; set; }
       
        public string EmpName { get; set; }
       
        public string Surname { get; set; }
        public bool IsDeleted { get; set; }
       
        public decimal Salary { get; set; }
        public virtual Sector Sector { get; set; }
        public int SectorId { get; set; }
       
    }
}
