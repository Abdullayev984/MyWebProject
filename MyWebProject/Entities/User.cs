using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.Entities
{
    public class User
    {
        public int UserId { get; set; }
      
       
        public string UserName { get; set; }
      
        public string UserPassword { get; set; }
       
        public string ConfirmPassword { get; set; }
        public bool IsDeleted { get; set; }
    }
}
