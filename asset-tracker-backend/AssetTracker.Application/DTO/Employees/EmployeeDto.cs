using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.DTO.Employees
{
    public class EmployeeDto
    {

        public int Id { get; set; }
        public string FullName { get; set; } = null!; //Not null

        public string Email { get; set; } = null!;  //Not null

        public int DepartmentId { get; set; }
    }
}
