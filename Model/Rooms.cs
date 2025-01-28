using IndoorNavigationSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigationSystem.Model
{
    public class Rooms : IRooms
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public Dictionary<Rooms, int>? Connections { get; set; } // Connections to other rooms and their distances
        public Rooms(int id,string name,string type,int row,int column)
        {

            Id = id;
            Name = name;
            Type = type;
            Row = row;
            Column = column;
            Connections = new Dictionary<Rooms, int>();
        }

        public Rooms()
        {
            Connections= new Dictionary<Rooms, int>();
        }

        public void AddConnection(Rooms room, int distance)
        {
            Connections[room] = distance;
        }
    }
}
