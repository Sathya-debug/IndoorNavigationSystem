using IndoorNavigationSystem.Interface;
using IndoorNavigationSystem.Model;
using IndoorNavigationSystem.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigationSystem.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            // Set up Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddScoped<IRoomService, RoomService>()
                .AddSingleton<IRooms, Rooms>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
