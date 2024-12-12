using CodefirstDemo.Data;
using CodefirstDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CodefirstDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create - POST: api/employee
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        // Read - GET: api/employee
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        // Read - GET: api/employee/{id}
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound($"Employee with Id {id} not found.");
            }

            return Ok(employee);
        }

        // Update - PUT: api/employee/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null || id != employee.Id)
            {
                return BadRequest("Employee data is invalid.");
            }

            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with Id {id} not found.");
            }

            existingEmployee.name = employee.name;
            existingEmployee.age = employee.age;
            existingEmployee.phone = employee.phone;
            existingEmployee.email = employee.email;
            //existingEmployee.phoneNumber = employee.phoneNumber;
            existingEmployee.city = employee.city;
            existingEmployee.country = employee.country;
            existingEmployee.zipcode = employee.zipcode;
            existingEmployee.city_name = employee.city_name;
            existingEmployee.country_name = employee.country_name;

            _context.SaveChanges();

            return NoContent(); // 204 No Content
        }

        // Delete - DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound($"Employee with Id {id} not found.");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return NoContent(); // 204 No Content
        }
    }
}
