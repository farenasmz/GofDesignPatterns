using AbstractFactory.Service;

namespace AbstractFactory.WebService
{
    public class EmployeeServiceWS : IEmployeeService
    {
        public string[] GetEmployees()
        {
            return new string[] { "Juan", "Pedro", "Luis" };
        }
    }
}
