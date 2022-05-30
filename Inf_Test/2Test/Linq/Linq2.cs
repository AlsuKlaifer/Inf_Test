using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf_Test._2Test.Linq
{
    public class Linq2
    {
        /*1 Вариант
Создать список яхт (id, наименование, id владельца, стоимость) не менее 10 и 
        список владельцев яхт (id, имя, возраст) не менее 5. Сделать так, что один владелец может владеть несколькими яхтами
1)  Вывести список наименование яхты, имя владельца (без циклов foreach/for/while)
2)  Вывести список имя владельца, абсолютная сумма по всем яхтам, которыми он владеет, средняя стоимость яхт, которыми он владеет
3)  Вычислить среднюю стоимость яхт у владельцев двух яхт
        */
        public class Yacht
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int RichManId { get; set; }
            public int Sum { get; set; } //millions
        }

        public class RichMan
        {
            public int Id { get; set; }
            public string Name1 { get; set; }
            public int Age { get; set; }
        }

        public void Run()
        {
            var yachts = new List<Yacht>
            {
                new Yacht { Id = 1, Name = "Grace", RichManId = 1, Sum = 12},
                new Yacht { Id = 2, Name = "Freedom", RichManId = 1, Sum = 13},
                new Yacht { Id = 3, Name = "Therapy", RichManId = 2, Sum = 12},
                new Yacht { Id = 4, Name = "Dimond", RichManId = 2, Sum = 27},
                new Yacht { Id = 5, Name = "Sun", RichManId = 2, Sum = 20},
                new Yacht { Id = 6, Name = "Cloud", RichManId = 3, Sum = 2},
                new Yacht { Id = 7, Name = "BigYacht", RichManId = 4, Sum = 10},
                new Yacht { Id = 8, Name = "Wow", RichManId = 4, Sum = 17},
                new Yacht { Id = 9, Name = "Molly", RichManId = 5, Sum = 18},
                new Yacht { Id = 10, Name = "TNT", RichManId = 5, Sum = 19},
            };

            var richMans = new List<RichMan>
            {
                new RichMan { Id = 1, Age = 35, Name1 = "Richard"},
                new RichMan { Id = 2, Age = 46, Name1 = "Michael"},
                new RichMan { Id = 3, Age = 40, Name1 = "Dmitriy"},
                new RichMan { Id = 4, Age = 54, Name1 = "Alexandr"},
                new RichMan { Id = 5, Age = 32, Name1 = "Dave"},
            };

            //1)  Вывести список наименование яхты, имя владельца (без циклов foreach/for/while)
            //вроде правильно написано, но не работает!!((
            var result1 = yachts.Join(richMans,
                y => y.RichManId,
                rM => rM.Id,
                (y, rM) => new {y.Name, rM.Name1}) 
                .ToList()
                .ForEach(x => Console.WriteLine($"Yacht - {x.Name}. Owner - {x.Name1}"));

            //2)  Вывести список имя владельца, абсолютная сумма по всем яхтам, которыми он владеет, средняя стоимость яхт, которыми он владеет
            var result2 = yachts
                .GroupBy(x => x.RichManId)
                .Select(g => new { g.Key, g.Sum, AvSum = g.Average(y => y.Sum) })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key} - {x.AvSum}"));
            //3
        }
    }
}
