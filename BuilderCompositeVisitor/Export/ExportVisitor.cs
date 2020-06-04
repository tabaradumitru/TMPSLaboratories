using System;

namespace BuilderCompositeVisitor.Export
{
    public class ExportVisitor : IExportVisitor
    {
        public void ExportEmployee(Employee employee)
        {
            Console.WriteLine(employee.GetInfo());
        }

        public void ExportDepartment(Department department)
        {
            Console.WriteLine(department.GetInfo());
        }
    }
}