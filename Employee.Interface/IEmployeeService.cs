using Employee.Entity.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeService
    {
        List<EmployeeDetail> GetEmployeeDetails();

        List<EmployeeDetail> EditEmployeeDetails(List<EmployeeDetail> lstEmpDetails);
    }
}
