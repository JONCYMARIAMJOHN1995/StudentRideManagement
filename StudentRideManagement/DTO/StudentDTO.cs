using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.DTO
{
    public class StudentDTO
    {
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
