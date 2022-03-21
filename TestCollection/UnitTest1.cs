using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inf_Test.CustomLists;

namespace TestCollection
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdding()
        {
            var clist = new LinkedListDeque<int>();
            clist.AddFirst(1);
            clist.AddFirst(2); 
            clist.AddLast(3); 
            clist.AddLast(4); 

            Assert.AreEqual<string>("2 1 3 4", clist.ToString().Trim());
        }
        [TestMethod]
        public void TestDleting()
        {
            var clist = new LinkedListDeque<int>();
            clist.AddFirst(1);
            clist.AddFirst(2);
            clist.AddLast(3);
            clist.AddLast(4);

            clist.RemoveLast();
            clist.RemoveFirst();

            Assert.AreEqual<string>("1 3", clist.ToString().Trim());
        }
        [TestMethod]
        public void TestIsEmpty()
        {
            var clist = new CustomLinkedList<int>();
            clist.isEmpty();
            Assert.AreEqual<bool>(string.IsNullOrEmpty(""), clist.isEmpty());
        }
        [TestMethod]
        public void TestSize()
        {
            var clist = new CustomLinkedList<int>(new int[] {1, 2, 3});
            Assert.AreEqual<int>(3, clist.Size());
        }
    }
}