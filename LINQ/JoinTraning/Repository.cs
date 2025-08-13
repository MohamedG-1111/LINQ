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
        new Worker { Id = 4, Name = "Laila", DepartmentId = 3 }
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
        new Project { Id = 103, Name = "Database Upgrade" }
    };

        public static List<EmployeeProject> LoadEmployeeProjects() => new()
    {
        new EmployeeProject { EmployeeId = 1, ProjectId = 101 },
        new EmployeeProject { EmployeeId = 1, ProjectId = 103 },
        new EmployeeProject { EmployeeId = 2, ProjectId = 102 },
        new EmployeeProject { EmployeeId = 3, ProjectId = 101 },
        new EmployeeProject { EmployeeId = 4, ProjectId = 102 },
        new EmployeeProject { EmployeeId = 4, ProjectId = 103 },
        new EmployeeProject { EmployeeId = 4, ProjectId = 103 }
    };
    }
}
