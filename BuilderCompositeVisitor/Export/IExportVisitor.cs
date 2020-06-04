namespace BuilderCompositeVisitor.Export
{
    public interface IExportVisitor
    {
        void ExportEmployee(Employee employee);
        void ExportDepartment(Department department);
    }
}