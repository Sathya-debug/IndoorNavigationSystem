using IndoorNavigationSystem.Interface;
using IndoorNavigationSystem.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml;

namespace IndoorNavigationSystem.Services
{
    public class RoomService : IRoomService
    {
        #region usinggraph
        // Define grid size
        public static int rows = 3;  // Number of rows in the grid
        public static int cols = 3;  // Number of columns in the grid
        public static Dictionary<string, Rooms> allRooms = new Dictionary<string, Rooms>();

        // Define start and goal rooms
        Rooms startRoom;
        Rooms goalRoom;

        // Function to initialize the graph
        static void InitializeGraph()
        {
            allRooms.Add("RoomA", new Rooms() { Id = 1, Name = "Library", Type = "Reading", Row = 0, Column = 0 });
            allRooms.Add("RoomB", new Rooms() { Id = 2, Name = "Restroom", Type = "Restroom", Row = 0, Column = 1 });
            allRooms.Add("RoomC", new Rooms() { Id = 3, Name = "Dormroom", Type = "Dormitory", Row = 1, Column = 1 });
            allRooms.Add("RoomD", new Rooms() { Id = 4, Name = "Visitorsroom", Type = "Visiting", Row = 0, Column = 2 });
            allRooms.Add("RoomE", new Rooms() { Id = 5, Name = "Diningroom", Type = "Eating", Row = 2, Column = 1 });

            // Create rooms
            var roomA = allRooms["RoomA"];
            var roomB = allRooms["RoomB"];
            var roomC = allRooms["RoomC"];
            var roomD = allRooms["RoomD"];
            var roomE = allRooms["RoomE"];

            // Define distances (connections between rooms)
            roomA.AddConnection(roomB, 20);
            roomA.AddConnection(roomC, 35);
            roomA.AddConnection(roomD, 30);
            roomA.AddConnection(roomE, 60);
            roomB.AddConnection(roomA, 20);
            roomB.AddConnection(roomC, 35);
            roomB.AddConnection(roomD, 15);
            roomC.AddConnection(roomA, 35);
            roomC.AddConnection(roomB, 10);
            roomC.AddConnection(roomD, 20);
            roomC.AddConnection(roomE, 40);
            roomD.AddConnection(roomA, 30);
            roomD.AddConnection(roomB, 15);
            roomD.AddConnection(roomC, 20);
            roomD.AddConnection(roomE, 15);
            roomE.AddConnection(roomA, 60);
            roomE.AddConnection(roomC, 40);
            roomE.AddConnection(roomD, 15);
        }        

        public void DisplayRooms()
        {
            try
            {
                //Display all available rooms to user
                Console.WriteLine($"Below Rooms are available in the floor:\n");
                InitializeGraph();                
                //Displaying all the Rooms details to user
                foreach (var room in allRooms)
                {
                    Console.WriteLine($"{room.Value.Id} - {room.Key} - {room.Value.Name} is at position ({room.Value.Row}, {room.Value.Column}) - {room.Value.Type}\n");
                }
            }
            catch (IOException iex)
            {
                Console.WriteLine($"Failed to read file from the path: {iex.Message}", iex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DefineNode(int sKey, int dKey)
        {
            var strt = allRooms.FirstOrDefault(kvp => kvp.Value.Id == sKey).Key;
            var goal = allRooms.FirstOrDefault(kvp => kvp.Value.Id == dKey).Key;
            // Define start and goal rooms
            startRoom = allRooms[strt];
            goalRoom = allRooms[goal];
        }

        public void DisplayPath()
        {
            // Create a list of rooms (graph of rooms)
            List<Rooms> rooms = allRooms.Values.ToList();

            // Apply A* algorithm
            var aStar = new AStarSearch(rooms, startRoom, goalRoom);
            var path = aStar.FindShortestPath();

            // Display the path
            if (path != null)
            {
                Console.Write($"\nShortest path is \n{allRooms.FirstOrDefault(kvp => kvp.Value.Id == Convert.ToInt32(startRoom.Id)).Key} ({startRoom.Name}) -> ");
                foreach (var room in path)
                {
                    var value = allRooms.FirstOrDefault(kvp => kvp.Value.Id == Convert.ToInt32(room.Id)).Key;
                    if (!(goalRoom.Name.Equals(room.Name))) {
                        Console.Write($"{allRooms.FirstOrDefault(kvp => kvp.Value.Id == Convert.ToInt32(goalRoom.Id)).Key} ({room.Name}) ->");
                    }
                    else
                    {
                        Console.WriteLine($"{value}({room.Name})");
                    }
                }
            }
            else
            {
                Console.WriteLine("No path found.");
            }
        }
        #endregion
    }
}
