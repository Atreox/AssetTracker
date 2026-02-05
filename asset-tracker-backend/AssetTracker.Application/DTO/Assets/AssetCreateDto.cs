using AssetTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.DTO.Assets
{
    public class AssetCreateDto
    {
        public string AssetName { get; set; } = null!;

        public string SerialNumber { get; set; } = null!;

        public string AssetType { get; set; } = null!;

        public DateTime PurchaseDate { get; set; }
        //public Employee? Employee { get; set; }

        //public int? EmployeeId { get; set; }
    }
}
