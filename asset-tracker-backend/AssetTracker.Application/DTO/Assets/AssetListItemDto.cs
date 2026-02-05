using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.DTO.Assets
{
    public sealed record AssetListItemDto(
    int Id,
    string AssetName,
    string SerialNumber,
    string AssetType,
    DateTime PurchaseDate,
    int? EmployeeId,
    string? EmployeeName,
    int? DepartmentId,
    string? DepartmentName
);

}
