using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.Models
{
    public class DepartmentToListDTO
    {
        public int DepartmentId { get; set; }
      
        public string DepartmentName { get; set; }

        public bool IsDeleted { get; set; }
       
    }
}
