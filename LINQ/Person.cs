using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Person:IComparable<Person>   
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Name : {Name} , Age : {Age}";
        }
        public int CompareTo(Person? p)
        {
            if (p == null) return -1;
            if (Object.ReferenceEquals(this, p))
                return 0;
            return this.Id.CompareTo(p.Id);


        }
        public override bool Equals(object? obj)
        {
            var p = obj as Person;
            if (p == null) return false;
            return this.Id.Equals(p.Id) && this.Name.Equals(p.Name);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.Id.GetHashCode();
            hash = hash * 23 + Name.GetHashCode();
            return hash;
        }
    }
    //public record Employee(string Name, string Department, int Salary);
    }
