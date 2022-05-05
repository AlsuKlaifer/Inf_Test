using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Event
{
    public class NewFlatEventArgs : EventArgs
    {
        private string name;
        private int rooms;
        private int price;
        public NewFlatEventArgs(string name, int rooms, int price)
        {
            this.name = name;
            this.rooms = rooms;
            this.price = price;
        }
        public string Name { get { return name; } }
        public int Rooms { get { return rooms; } }
        public int Price { get { return price; } }
    }
}
