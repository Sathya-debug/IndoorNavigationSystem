using IndoorNavigationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigationSystem.Interface
{
    public interface IRooms
    {
        int Id { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        int Row { get; set; }
        int Column { get; set; }
        Dictionary<Rooms, int>? Connections { get; set; }
        void AddConnection(Rooms room, int distance);
    }
}
