﻿// See https://aka.ms/new-console-template for more information
using Inf_Test.CustomLists;

var list = new CustomLinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6 });
list.RemoveTheThirdFromEnd();
list.WriteToConsole();

var deq = new LinkedListDeque<int>();
deq.AddFirst(1);
deq.AddLast(2);
foreach(var item in deq)
    Console.WriteLine(item);

foreach (var i in list)
    Console.WriteLine(i);