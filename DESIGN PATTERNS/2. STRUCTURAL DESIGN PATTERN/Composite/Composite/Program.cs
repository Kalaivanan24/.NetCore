using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {

        interface IOrganizationComponent
        {
            string Name { get; }
            void Display();
        }

        class Employee : IOrganizationComponent
        {
            public string Name { get; private set; }

            public Employee(string name)
            {
                Name = name;
            }

            public void Display()
            {
                Console.WriteLine($"Employee: {Name}");
            }
        }

        class Department : IOrganizationComponent
        {
            public string Name { get; private set; }
            private List<IOrganizationComponent> components = new List<IOrganizationComponent>();

            public Department(string name)
            {
                Name = name;
            }

            public void Add(IOrganizationComponent component)
            {
                components.Add(component);
            }

            public void Display()
            {
                Console.WriteLine($"Department: {Name}");
                foreach (var component in components)
                {
                    component.Display();
                }
            }
        }




        static void Main(string[] args)
        {
            var ceo = new Department("CEO Office");
            var hrDepartment = new Department("HR Department");
            var techDepartment = new Department("Tech Department");

            ceo.Add(new Employee("John CEO"));
            ceo.Add(hrDepartment);
            ceo.Add(techDepartment);

            hrDepartment.Add(new Employee("Alice HR"));
            hrDepartment.Add(new Employee("Bob HR"));

            techDepartment.Add(new Employee("Eve Developer"));
            techDepartment.Add(new Employee("Charlie Developer"));

            ceo.Display();
        }
    }

}
