using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace LinkedListTests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void InsertInOrder_Should_Insert_Values_Correctly()
        {
            var list = new DoublyLinkedList();
            list.InsertInOrder(5);
            list.InsertInOrder(1);
            list.InsertInOrder(3);

            Assert.AreEqual(1, list.DeleteFirst());
            Assert.AreEqual(3, list.DeleteFirst());
            Assert.AreEqual(5, list.DeleteFirst());
        }

        [TestMethod]
        public void DeleteFirst_Should_Throw_Exception_If_Empty()
        {
            var list = new DoublyLinkedList();
            Assert.ThrowsException<InvalidOperationException>(() => list.DeleteFirst());
        }

        [TestMethod]
        public void DeleteLast_Should_Throw_Exception_If_Empty()
        {
            var list = new DoublyLinkedList();
            Assert.ThrowsException<InvalidOperationException>(() => list.DeleteLast());
        }

        [TestMethod]
        public void DeleteValue_Should_Return_True_If_Found()
        {
            var list = new DoublyLinkedList();
            list.InsertInOrder(1);
            list.InsertInOrder(2);
            list.InsertInOrder(3);

            Assert.IsTrue(list.DeleteValue(2));
        }

        [TestMethod]
        public void GetMiddle_Should_Return_Middle_Element()
        {
            var list = new DoublyLinkedList();
            list.InsertInOrder(1);
            list.InsertInOrder(2);
            list.InsertInOrder(3);

            Assert.AreEqual(2, list.GetMiddle());
        }

        [TestMethod]
        public void InvertList_Should_Invert_The_List()
        {
            var list = new DoublyLinkedList();
            list.InsertInOrder(1);
            list.InsertInOrder(2);
            list.InsertInOrder(3);

            list.InvertList();

            Assert.AreEqual(3, list.DeleteFirst());
            Assert.AreEqual(2, list.DeleteFirst());
            Assert.AreEqual(1, list.DeleteFirst());
        }

        [TestMethod]
        public void MergeSorted_Should_Merge_Two_Lists_Ascending()
        {
            var listA = new DoublyLinkedList();
            listA.InsertInOrder(1);
            listA.InsertInOrder(3);

            var listB = new DoublyLinkedList();
            listB.InsertInOrder(2);
            listB.InsertInOrder(4);

            listA.MergeSorted(listA, listB, SortDirection.Asc);

            Assert.AreEqual(1, listA.DeleteFirst());
            Assert.AreEqual(2, listA.DeleteFirst());
            Assert.AreEqual(3, listA.DeleteFirst());
            Assert.AreEqual(4, listA.DeleteFirst());
        }
    }
}
