using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Event
{
    internal sealed class Buyer
    {
        public void Subscribe(Bank b)
        {
            b.NewFlat += BeginToPay;
        }

        public void UnSubscribe(Bank b)
        {
            b.NewFlat -= BeginToPay;
        }
        private void BeginToPay(object sender, NewFlatEventArgs e)
        {
            Console.WriteLine($"Покупатель начал выплачивать платежи. Имя владельца: {e.Name}." +
                $" Кол-во комнат: {e.Rooms}. Цена (млн): {e.Price}");
        }
    }
}
