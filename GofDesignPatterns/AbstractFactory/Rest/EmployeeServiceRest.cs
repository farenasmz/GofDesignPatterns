using AbstractFactory.Service;

namespace AbstractFactory.Rest
{
    internal class EmployeeServiceRest : IEmployeeService
    {
        public string[] GetEmployees()
        {
            return new string[] { "Juan", "Pedro", "Carlos" };
        }
    }
}
