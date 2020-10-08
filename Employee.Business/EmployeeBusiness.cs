using Employee.DataAccessLayer;
using Employee.Entity.Modal;
using Employee.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BusinessAccessLayer
{
    public class EmployeeBusiness : IEmployeeService
    {
        List<EmployeeDetail> lstEmpDetails = new List<EmployeeDetail>();
        EmployeeDataLayer empDataLayer = new EmployeeDataLayer();

        public EmployeeBusiness()
        {
            lstEmpDetails = new List<EmployeeDetail>();
            empDataLayer = new EmployeeDataLayer();
        }

        public List<EmployeeDetail> GetEmployeeDetails()
        {
            try
            {
                lstEmpDetails = empDataLayer.GetEmployeeDetails();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return lstEmpDetails;
        }

        public List<EmployeeDetail> EditEmployeeDetails(List<EmployeeDetail> lstEmpDetails)
        {
            try
            {
                lstEmpDetails = empDataLayer.EditEmployeeDetails(lstEmpDetails);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return lstEmpDetails;
        }
    }
}
