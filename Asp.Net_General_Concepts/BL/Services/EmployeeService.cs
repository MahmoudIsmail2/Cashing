using Asp.Net_General_Concepts.BL.Interfaces;

namespace Asp.Net_General_Concepts.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Simulates retrieving employee data from an external resource.
        /// This operation is artificially delayed by 5 seconds to mimic the time it would take 
        /// to fetch data from a slow external service or database.
        /// </summary>
        /// <returns>An array of employee names.</returns>
        public string[] GetEmployees()
        {
            // Simulate a delay representing the time it takes to retrieve data from an external resource.
            Thread.Sleep(5000);

            return new string[] { "Mahmoud", "Ali", "Yasser", "Ahmed" };
        }

    }
}
