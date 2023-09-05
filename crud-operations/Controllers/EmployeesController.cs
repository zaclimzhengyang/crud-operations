using System.Runtime.InteropServices.JavaScript;
using crud_operations.Data;
using crud_operations.Models;
using crud_operations.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace crud_operations.Controllers;

[Route("api/[controller]/[action]")]
public class EmployeesController : Controller
{
    private readonly MvcDbContext mvcDbContext;
    
    public EmployeesController(MvcDbContext mvcDbContext)
    {
        this.mvcDbContext = mvcDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var employees = await mvcDbContext.Employees.ToListAsync();
        return View(employees);
    }
    
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
    {
        var employee = new Employee()
        {
            Id = Guid.NewGuid(),
            Name = addEmployeeRequest.Name,
            Email = addEmployeeRequest.Email,
            Salary = addEmployeeRequest.Salary,
            Department = addEmployeeRequest.Department,
            DateOfBirth = addEmployeeRequest.DateOfBirth
        };

        await mvcDbContext.Employees.AddAsync(employee);
        await mvcDbContext.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    // [Route("Employees/Update/{id}")]
    // [HttpPost("Employees/Update/{id}")]
    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        Console.WriteLine("enter update");
        var employee = await mvcDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        
        if (employee != null)
        {
            Console.WriteLine("employee: " + employee);
            var employeeViewModel = new UpdateEmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Salary = employee.Salary,
                Department = employee.Department,
                DateOfBirth = employee.DateOfBirth
            };
            return await Task.Run(() => View("Update", employeeViewModel));
        }
        Console.WriteLine("employee is null");

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> View(UpdateEmployeeViewModel model)
    {
        var employee = await mvcDbContext.Employees.FindAsync(model.Id);
        if (employee != null)
        {
            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.Salary = model.Salary;
            employee.DateOfBirth = model.DateOfBirth;
            employee.Department = model.Department;

            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(UpdateEmployeeViewModel updateEmployeeViewModel)
    {
        var employee = await mvcDbContext.Employees.FindAsync(updateEmployeeViewModel.Id);

        if (employee != null)
        {
            mvcDbContext.Employees.Remove(employee);
            await mvcDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
    
}