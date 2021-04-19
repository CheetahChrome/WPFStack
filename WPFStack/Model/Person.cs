using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStack.Model
{

public class People : List<Person> { }

public class Person
{
    public string First { get; set; }
    public string Last { get; set; }
    public string Phone { get; set; }
    public string Name => $"{First} {Last}"; 
}


    public class Employees : List<Employee> { }
    public class Employee 
    {
        public string EmployeeId { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Phone { get; set; }

    }

}
