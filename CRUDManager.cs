using EFDBFirst.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDBFirst.Data
    {
        public class CRUDManager
        {
            DBFirstContext dBFirstContext = new DBFirstContext();
            public Employee GetEmplpoyeeById(int employeeId)
            {
                
                var employee = dBFirstContext.Employees.Where(x => x.Name == "Dipakshi")
                                .AsNoTracking().OrderBy(s => s.Name).ThenByDescending(s => s.Address)
                                .Last();

                if (employee == null)
                {
                    throw new Exception($"Employee with ID:{employeeId} Not Found");
                }

                return employee;
            }

            public List<Employee> GetAllEmployees()
            {
                var employee = dBFirstContext.Employees.ToList();
                return employee;
            }

            public void Insert(Employee employee)
            {
                dBFirstContext.Employees.Add(employee);
                dBFirstContext.SaveChanges();
            }

            public void Update(int employeeId, Employee modifiedEmployee)
            {
                var employee = dBFirstContext.Employees.Where(x => x.Id == employeeId).FirstOrDefault();
                if (employee == null)
                {
                    Console.WriteLine($"Employee with ID:{employeeId} Not Found");
                }

                employee.Name = modifiedEmployee.Name;
                employee.Address = modifiedEmployee.Address;

                // Entity state : Modified
                dBFirstContext.Employees.Update(employee);

                // This issues insert statement
                dBFirstContext.SaveChanges();
            }

            public void Delete(int employeeId)
            {
                var employee = dBFirstContext.Employees.Where(x => x.Id == employeeId).FirstOrDefault();
                if (employee == null)
                {
                    throw new Exception($"Employee with ID:{employeeId} Not Found");
                }

                // Entity state : Deleted
                dBFirstContext.Employees.Remove(employee);

                // This issues insert statement
                dBFirstContext.SaveChanges();
            }

         
        }
    
}

