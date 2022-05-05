using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Event
{
    public class Bank
    {
        /// <summary>
        /// Событие
        /// </summary>
        public event EventHandler<NewFlatEventArgs> NewFlat;
        /// <summary>
        /// Обработка события
        /// </summary>
        protected virtual void OnNewFlat(NewFlatEventArgs args)
        {
            EventHandler<NewFlatEventArgs> temp = Volatile.Read(ref NewFlat);
            if(temp != null) temp.Invoke(this, args);
        }
        /// <summary>
        /// Симуляция события
        /// </summary>
        public void SimulateFlat(string name, int rooms, int price)
        {
            var args = new NewFlatEventArgs(name, rooms, price);
            OnNewFlat(args);
        }
    }
}
