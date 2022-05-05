using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Event
{
    public class BankRunner
    {
        public void Run()
        {
            var b = new Bank();
            b.SimulateFlat("Рената", 3, 7);

            var developer = new Developer();
            developer.Subscribe(b);
            b.SimulateFlat("Alsu", 1, 3);

            var registration = new Registration();
            registration.Subscribe(b);
            developer.UnSubscribe(b);
            b.SimulateFlat("Bulat", 2, 5);
        }
    }
}
