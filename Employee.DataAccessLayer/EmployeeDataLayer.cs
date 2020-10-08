using Employee.Entity.Modal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DataAccessLayer
{
    public class EmployeeDataLayer
    {

        List<EmployeeDetail> lstEmpDetails = new List<EmployeeDetail>();
        public EmployeeDataLayer()
        {
            lstEmpDetails = new List<EmployeeDetail>();
        }
        public List<EmployeeDetail> GetEmployeeDetails()
        {
            try
            {
                if (File.Exists(Path.Combine(@"E:\Work\Assessment\EmployeeServiceAPI\EmployeeServiceAPI\Employee.DataAccessLayer\Employee Data\", "EmployeeData.txt")) &&
                  File.Exists(Path.Combine(@"E:\Work\Assessment\EmployeeServiceAPI\EmployeeServiceAPI\Employee.DataAccessLayer\Employee Data\", "EmployeeData.txt")))
                {
                    var empDetails = File.ReadLines(Path.Combine(@"E:\Work\Assessment\EmployeeServiceAPI\EmployeeServiceAPI\Employee.DataAccessLayer\Employee Data\", "EmployeeData.txt"))
                        .Select(line => line.Split(','));


                    lstEmpDetails.AddRange(empDetails.Select(x => new EmployeeDetail
                    {
                        UserId = int.Parse(x[0]),
                        FirstName = x[1],
                        LastName = x[2],
                        Email = x[3],
                        DateOfBirth = Convert.ToDateTime(x[4]),
                        PhoneNumber = x[5]
                    }));
                }

                return lstEmpDetails;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public List<EmployeeDetail> EditEmployeeDetails(List<EmployeeDetail> lstEmpDetails)
        {
            try
            {
                if (File.Exists(Path.Combine(@"E:\Work\Assessment\EmployeeServiceAPI\EmployeeServiceAPI\Employee.DataAccessLayer\Employee Data\", "EmployeeData.txt")) &&
                  File.Exists(Path.Combine(@"E:\Work\Assessment\EmployeeServiceAPI\EmployeeServiceAPI\Employee.DataAccessLayer\Employee Data\", "EmployeeData.txt")))
                {
                    var editDetails = (IEnumerable<string>)lstEmpDetails;
                    File.WriteAllLines(@"E:\Work\Assessment\EmployeeServiceAPI\EmployeeServiceAPI\Employee.DataAccessLayer\Employee Data\EmployeeData.txt", editDetails);
                }
                return GetEmployeeDetails();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
