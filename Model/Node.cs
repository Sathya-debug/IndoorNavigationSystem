using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorNavigationSystem.Model
{
    public class Node
    {
        public Rooms Room { get; set; }
        public int GCost { get; set; } // Cost from start to this node
        public int HCost { get; set; } // Heuristic cost (estimated from this node to goal)
        public int FCost => GCost + HCost; // Total cost (G + H)
        public Node Parent { get; set; }

        public Node(Rooms room)
        {
            Room = room;
            GCost = int.MaxValue; // Initially, set GCost to infinity
            HCost = 0;
            Parent = null;
        }
    }
}
