using System.Collections.Generic;
using System.Linq;
using BuilderCompositeVisitor.Export;

namespace BuilderCompositeVisitor
{
    public class Department : HRComponent
    {
        public string DepartmentName;
        public Employee Manager;
        public Address Address;
        private readonly List<HRComponent> _children = new List<HRComponent>();

        public override void Add(HRComponent component)
        {
            _children.Add(component);
        }

        public override void Remove(HRComponent component)
        {
            _children.Remove(component);
        }

        public override decimal GetSalary() // Returns 
        {
            return _children.Sum(component => component.GetSalary());
        }

        public IEnumerable<EmployeeDepartment> GetDepartmentEmployees()
        {
            var list = _children.OfType<Employee>().ToList();

            return list
                .Select(l => new EmployeeDepartment
                {
                    FirstName = l.FirstName,
                    LastName = l.LastName,
                    DepartmentName = DepartmentName
                })
                .ToList();
        }

        public override void Export(IExportVisitor v)
        {
            v.ExportDepartment(this);
        }

        public override string GetInfo()
        {
            var children = _children.Select(c => c.GetInfo()).ToList();

            var info = children.Aggregate("", (current, child) => current + child);

            return $"Department Name => {DepartmentName};\n" +
                   $"Department Manager => \n{Manager.GetInfo()}" +
                   $"Department Address => \n{GetAddress()}" +
                   $"Department Structure => \n{info}\n";
        }

        private string GetAddress()
        {
            return $"\tName: {Address.Name}\n" +
                   $"\tLine1: {Address.Line1}\n" +
                   $"\tLine2: {Address.Line2}\n" +
                   $"\tCity: {Address.City}\n" +
                   $"\tPostal Code: {Address.PostalCode}\n" +
                   $"\tCountry: {Address.Country}\n";
        }
    }
}