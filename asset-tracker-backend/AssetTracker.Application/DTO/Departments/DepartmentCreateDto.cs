using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.DTO.Departments
{
    public class DepartmentCreateDto
    {

        public string DeptName { get; set; } = null!; //Unique not null
        public string Location { get; set; }
    }
}
