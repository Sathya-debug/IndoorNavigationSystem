using IndoorNavigationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigationSystem.Services
{
    public class AStarSearch
    {
        private Rooms _start;
        private Rooms _goal;
        private List<Rooms> _rooms;

        public AStarSearch(List<Rooms> rooms, Rooms start, Rooms goal)
        {
            _rooms = rooms;
            _start = start;
            _goal = goal;
        }

        public List<Rooms> FindShortestPath()
        {
            var openList = new List<Node>();
            var closedList = new List<Node>();
            var startNode = new Node(_start) { GCost = 0, HCost = Heuristic(_start, _goal) };
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                openList.Sort((a, b) => a.FCost.CompareTo(b.FCost)); // Sort by FCost
                var currentNode = openList[0];
                openList.RemoveAt(0);
                closedList.Add(currentNode);

                // If we reach the goal, reconstruct the path
                if (currentNode.Room == _goal)
                {
                    var path = new List<Rooms>();
                    while (currentNode.Parent != null)
                    {
                        path.Add(currentNode.Room);
                        currentNode = currentNode.Parent;
                    }
                    path.Reverse();
                    return path;
                }

                foreach (var connection in currentNode.Room.Connections)
                {
                    var neighborRoom = connection.Key;
                    var distance = connection.Value;

                    if (closedList.Exists(n => n.Room == neighborRoom))
                        continue; // Skip already processed rooms

                    var neighborNode = openList.Find(n => n.Room == neighborRoom);
                    if (neighborNode == null)
                    {
                        neighborNode = new Node(neighborRoom);
                        openList.Add(neighborNode);
                    }

                    int tentativeGCost = currentNode.GCost + distance;
                    if (tentativeGCost < neighborNode.GCost)
                    {
                        neighborNode.GCost = tentativeGCost;
                        neighborNode.HCost = Heuristic(neighborRoom, _goal);
                        neighborNode.Parent = currentNode;
                    }
                }
            }

            return null; // No path found
        }

        private int Heuristic(Rooms current, Rooms goal)
        {
            // For simplicity, using a fixed heuristic (distance is calculated directly)
            return 0; // A simple case where we are just calculating the total distance
        }
    }
}
