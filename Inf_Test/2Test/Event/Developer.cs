using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Event
{
    public sealed class Developer
    {
        public void Subscribe(Bank b)
        {
            b.NewFlat += IsBuyed;
        }

        public void UnSubscribe(Bank b)
        {
            b.NewFlat -= IsBuyed;
        }
        private void IsBuyed(object sender, NewFlatEventArgs e)
        {
            Console.WriteLine($"Застройщик пометил квартиру как купленную. Имя владельца: {e.Name}." +
                $" Кол-во комнат: {e.Rooms}. Цена (млн): {e.Price}");
        }
    }
}
