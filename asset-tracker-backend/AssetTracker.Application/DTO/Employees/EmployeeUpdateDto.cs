using AssetTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.DTO.Employees
{
    public class EmployeeUpdateDto
    {
        public string FullName { get; set; } = null!; //Not null

        public string Email { get; set; } = null!;  //Not null

        public int DepartmentId { get; set; }

        //public Asset Deparment { get; set; } = null!;// FK; nullable istenmemiş ve departman silinince çalışanın silinmesi istenmiş.

        //public ICollection<Asset> Assets { get; set; } = new List<Asset>();

    }
}
