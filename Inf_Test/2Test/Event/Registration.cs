using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Event
{
    internal sealed class Registration
    {
        public void Subscribe(Bank b)
        {
            b.NewFlat += Ipoteka;
        }

        public void UnSubscribe(Bank b)
        {
            b.NewFlat -= Ipoteka;
        }
        private void Ipoteka(object sender, NewFlatEventArgs e)
        {
            Console.WriteLine($"Банк оканчивает оформление ипотеки за квартиру. Имя владельца: {e.Name}." +
                $" Кол-во комнат: {e.Rooms}. Цена (млн): {e.Price}");
        }
    }
}