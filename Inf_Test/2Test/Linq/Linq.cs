using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Linq
{
    /// <summary>
    /// просто на 3 балла, сложный на 5 баллов
    /// </summary>
    public class Linq
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Price
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public decimal Sum { get; set; }
            public bool IsActual { get; set; }
        }

        public void Run()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Аквариум 10 литров" },
                new Product { Id = 2, Name = "Аквариум 20 литров" },
                new Product { Id = 3, Name = "Аквариум 50 литров" },
                new Product { Id = 4, Name = "Аквариум 100 литров" },
                new Product { Id = 5, Name = "Аквариум 200 литров" },
                new Product { Id = 6, Name = "Фильтр" },
                new Product { Id = 7, Name = "Термометр" }
            };

            var prices = new List<Price>
            {
                new Price { Id = 1, ProductId = 1, Sum = 100, IsActual = false },
                new Price { Id = 2, ProductId = 1, Sum = 123, IsActual = true },
                new Price { Id = 3, ProductId = 2, Sum = 234, IsActual = true },
                new Price { Id = 4, ProductId = 3, Sum = 532, IsActual = true },
                new Price { Id = 5, ProductId = 4, Sum = 234, IsActual = true },
                new Price { Id = 6, ProductId = 5, Sum = 534, IsActual = true },
                new Price { Id = 7, ProductId = 5, Sum = 124, IsActual = false },
                new Price { Id = 8, ProductId = 6, Sum = 153, IsActual = true },
                new Price { Id = 9, ProductId = 7, Sum = 157, IsActual = true }
            };

            /*Задания              * 
             * 1) создать список счетов (один счет содержит несколько пар цена-количество)
             * например, один счет - это аквариум на 200 литров, два фильтра и термометр
             * 2) вывести счет для покупателя с колонками "Наименование услуги, сумма, итого"
             *  - 1 балл
             * 3) Вывести среднюю цену для каждого продукта с учетом неактуальных значений
             * - 1 балл
             * 4) создать список акций (код продукта, скидка):
             * аквариум на 200 литров + 2 фильтра - скидка 15%
             * аквариум 100 литров + 2 фильтра - 10% скидка
             * любой другой аквариум + фильтр - 5% скидка
             * 5) создать список перенчень всех названий товаров в группе акции + 
             * цена до скидки + цена с учетом скидки  - 1 балл
             * 
             * Для тех, кто выбрал вариант посложнее: написать функцию подсчета 
             * суммы покупки (выявлять, есть ли в наборе продуктов акционные комплекты,
             * при их наличии делать скидку) - это + 2 балла
             */

            //1 task
            var list1 = new List<Product>
            {
                new Product { Id = 5, Name = "Аквариум 200 литров" },
                new Product { Id = 6, Name = "Фильтр" },
                new Product { Id = 7, Name = "Термометр" },
            };
            var check = new Check(list1, prices);
            check.GetCheck(prices);

            //3 task
            foreach (var product in products)
            {
                var list3 = (from x in prices where x.ProductId == product.Id select x.Sum).ToList();
                decimal result = list3.Average();
                Console.WriteLine(result);
            }

            //4 task
            var list4 = new List<Discount> 
            {
                new Discount(1, 15),
                new Discount(3, 20)
            };

            var list5 = 
                (from l in list4
                from x in prices
                where (l.productId == x.ProductId && x.IsActual == true)
                select (products.First(z => z.Id == x.ProductId).Name, x.Sum, x.Sum * (1 - (l.Discountt / 100)))
            ).ToList();
            foreach (var b1 in list5)
            {
                Console.WriteLine($"{b1.Name} \t {b1.Sum} \t {b1.Item3}");
            }
        }

        public class Discount
        {
            public int productId;
            public int Discountt;
            public Discount(int id, int dis)
            {
                Discountt = dis;
                productId = id;
            }
        }
        /// <summary>
        /// Счет
        /// </summary>
        public class Check
        {
            private decimal money;
            private List<Product> products;
            public Check(List<Product> prod, List<Price> prices)
            {
                products = prod;
                var productsId = (from pr in products select pr.Id).ToList();
                var res = new List<decimal>();
                res = (from x in prices
                       where
      (productsId.Contains(x.ProductId) == true && x.IsActual == true)
                       select x.Sum).ToList();
                money = res.Sum();
            }
            public void GetCheck(List<Price> prices)
            {
                Console.WriteLine("Товары:");
                foreach (var product in products)
                {
                    string s1 = product.Name;
                    var price = prices.First(x => x.ProductId == product.Id);
                    s1 += Convert.ToString(price.Sum);
                }
                Console.WriteLine($"Итого: {money}");
            }
        }
    }
}
