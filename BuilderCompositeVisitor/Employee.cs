using System;
using BuilderCompositeVisitor.Export;

namespace BuilderCompositeVisitor
{
    public class Employee : HRComponent
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly int Role;
        private readonly decimal _salary;

        public Employee(string firstName, string lastName, int role)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override decimal GetSalary()
        {
            return _salary;
        }

        public override void Export(IExportVisitor v)
        {
            v.ExportEmployee(this);
        }

        public override string GetInfo()
        {
            return $"\tFirst Name: {FirstName}; Last Name: {LastName}; Role: {Enum.GetName(typeof(Role), Role)};\n";
        }
    }
}