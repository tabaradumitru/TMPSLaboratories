using BuilderCompositeVisitor.Builder;
using BuilderCompositeVisitor.Export;

namespace BuilderCompositeVisitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesAddress = new Address
            (
                "Tech Data Drop Ship", 
                "Tech Data Sales Management, Inc.", 
                "5350 Tech Data Drive",
                "Clearwater",
                "USA",
                "33760"
            );
            
            // Create the managers of each departments
            var salesManager = new Employee("John", "Radio", (int)Role.SalesManager);
            var teamASupervisor = new Employee("Dan", "Voly", (int)Role.SalesSupervisor);
            var teamBSupervisor = new Employee("Scott", "Sova", (int)Role.SalesSupervisor);
            
            // Create a director and set the director to use the builder to produce departments easier
            var director = new DepartmentDirector();
            var builder = new DepartmentBuilder();
            director.Builder = builder;
            
            // Build the first Sales Team
            director.BuildSalesDepartment("Sales Team A", teamASupervisor, salesAddress);
            
            var teamA = builder.GetDepartment();
            // Add leaves to our composite
            teamA.Add(new Employee("John", "Doe", (int)Role.SalesRepresentant));
            teamA.Add(new Employee("Adam", "Fin", (int)Role.SalesRepresentant));
            
            // Build the second Sales Team
            director.BuildSalesDepartment("Sales Team B", teamBSupervisor, salesAddress);

            var teamB = builder.GetDepartment();
            // Add leaves to the composite
            teamB.Add(new Employee("Mike", "Perry", (int)Role.SalesRepresentant));
            teamB.Add(new Employee("Alan", "Smith", (int)Role.SalesRepresentant));
            
            // Build Sales Department
            director.BuildSalesDepartment("Sales", salesManager, salesAddress);

            // Create the main composite
            var sales = builder.GetDepartment();
            // Add children to the main composite
            sales.Add(teamA);
            sales.Add(teamB);

            // Use Export Visitor to export information about both Leaves and Composite
            ExportVisitor exportVisitor = new ExportVisitor();
            sales.Export(exportVisitor);
            teamASupervisor.Export(exportVisitor);
        }
    }
}