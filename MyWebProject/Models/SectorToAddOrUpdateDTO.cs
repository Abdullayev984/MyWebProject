﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.Models
{
    public class SectorToAddOrUpdateDTO
    {
        public int? SectorId { get; set; }

        public string SectorName { get; set; }
        public bool IsDeleted { get; set; }
      
        public int DepartmentId { get; set; }
    }
}
