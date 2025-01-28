using IndoorNavigationSystem.Config;
using IndoorNavigationSystem.Interface;
using IndoorNavigationSystem.Model;
using IndoorNavigationSystem.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IndoorNavigationSystem
{
    public class Program
    {
        public static void Main()
        {
            //Get the service provider from DI Container
            var serviceProvider = DependencyInjectionConfig.ConfigureServices();

            // Resolve the services from the container
            var dataReader = serviceProvider.GetService<IRoomService>();

            Console.WriteLine("Hi,Welcome to Indoor Navigation System!\n");

            dataReader.DisplayRooms();

            try
            {
                //Enter a start room
                Console.WriteLine("Enter a start room Id(Enter a Number between 1 to 5): ");
                string startRoom = Console.ReadLine();
                int sKey = int.Parse(startRoom.Trim());

                //Enter a destination room
                Console.WriteLine("Enter a destination room Id(Enter a Number between 1 to 5): ");
                string destinRoom = Console.ReadLine();
                int dKey = int.Parse(destinRoom.Trim());

                //Call a method to find the shortest path
                dataReader.DefineNode(sKey,dKey);

                //Displaying the shortest route between the selected rooms, including total distance
                dataReader.DisplayPath();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Environment.Exit(0);
            }
            Console.WriteLine("\nHave a nice day!");
            Environment.Exit(0);
        }
    }
}
