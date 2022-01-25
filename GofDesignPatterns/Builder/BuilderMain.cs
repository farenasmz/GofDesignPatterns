using Builder.Dto;

namespace Builder
{
    public class BuilderMain
    {
        public void Action()
        {
            Employee employee = new EmployeeBuilder()
                .SetName("Fabian")
                .SetAddress("Calle luna calle sol", "Medellín", "Colombia", "Nop")
                .SetLastName("Arenas")
                .SetPhone("319361034", "", "")
                .Build();

            Console.WriteLine(employee.LastName);
        }
    }
}
