using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.Models
{
    public class UserToAddorUpdateDTO
    {
     
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsDeleted { get; set; }
    }
}
