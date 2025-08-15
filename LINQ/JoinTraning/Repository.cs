using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.JoinTraning
{
    static class Repository
    {
        public static List<Worker> LoadEmployees() => new()
    {
        new Worker { Id = 1, Name = "Ahmed", DepartmentId = 1 },
        new Worker { Id = 2, Name = "Sara", DepartmentId = 2 },
        new Worker { Id = 3, Name = "Omar", DepartmentId = 1 },
        new Worker { Id = 4, Name = "Laila", DepartmentId = 3 },
        new Worker { Id = 5, Name = "Ali", }
    };

        public static List<Department> LoadDepartments() => new()
    {
        new Department { Id = 1, Name = "HR" },
        new Department { Id = 2, Name = "IT" },
        new Department { Id = 3, Name = "Finance" },
        new Department { Id = 4, Name = "CS" }
    };

        public static List<Project> LoadProjects() => new()
    {
        new Project { Id = 101, Name = "Website" },
        new Project { Id = 102, Name = "Mobile App" },
        new Project { Id = 103, Name = "Database Upgrade" },
        new Project { Id = 104, Name = "Ai Model" }
    };

        public static List<EmployeeProject> LoadEmployeeProjects() => new()
    {
        new EmployeeProject { EmployeeId = 1, ProjectId = 101 },
        new EmployeeProject { EmployeeId = 1, ProjectId = 103 },
        new EmployeeProject { EmployeeId = 2, ProjectId = 102 },
        new EmployeeProject { EmployeeId = 3, ProjectId = 101 },
        new EmployeeProject { EmployeeId = 4, ProjectId = 102 },
        new EmployeeProject { EmployeeId = 4, ProjectId = 103 },
        new EmployeeProject { EmployeeId = 4, ProjectId = 104 }
    };
        public static List<TaskItem> LoadTasks() => new()
{
    new TaskItem { Id = 1, Name = "Design UI", ProjectId = 101, EmployeeId = 1 },
    new TaskItem { Id = 2, Name = "Backend API", ProjectId = 101, EmployeeId = 3 },
    new TaskItem { Id = 3, Name = "Testing", ProjectId = 102, EmployeeId = 2 },
    new TaskItem { Id = 4, Name = "Data Migration", ProjectId = 103, EmployeeId = 4 },
    new TaskItem { Id = 5, Name = "AI Training", ProjectId = 104, EmployeeId = 4 }
};
    }
}
