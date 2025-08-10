using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Name : {Name} , Age : {Age}";
        }
    }
    public record Employee(string Name, string Department, int Salary);
    }
