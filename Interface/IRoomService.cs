using IndoorNavigationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigationSystem.Interface
{
    // Interface for reading data from a JSON file
    public interface IRoomService
    {
        //void InitializeGraph();
        //void DefineRoom(int row, int col, string roomName);
        //Dictionary<string, Rooms> ReadJsonFile(string filePath);
        void DisplayRooms();
        void DefineNode(int sKey, int dKey);
        void DisplayPath();
    }
}
