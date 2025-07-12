using Microsoft.AspNetCore.Mvc;
using WebApi_Handson.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApi_Handson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Alice",
                Salary = 50000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "HR" },
                Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" } },
                DateOfBirth = new DateTime(1990, 1, 1)
            },
            new Employee
            {
                Id = 2,
                Name = "Bob",
                Salary = 60000,
                Permanent = false,
                Department = new Department { Id = 2, Name = "IT" },
                Skills = new List<Skill> { new Skill { Id = 2, Name = "Java" } },
                DateOfBirth = new DateTime(1991, 2, 2)
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return Ok(_employees);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var emp = _employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            // Update fields
            emp.Name = updatedEmployee.Name;
            emp.Salary = updatedEmployee.Salary;
            emp.Permanent = updatedEmployee.Permanent;
            emp.Department = updatedEmployee.Department;
            emp.Skills = updatedEmployee.Skills;
            emp.DateOfBirth = updatedEmployee.DateOfBirth;

            return Ok(emp);
        }
    }
}
