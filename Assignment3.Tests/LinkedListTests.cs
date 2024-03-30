using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Utility;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment3;
using System.Xml.Linq;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        private SLL linkedList;
        private User user1;
        private User user2;
        private User user3;

        [SetUp]
        public void Setup()
        {
            linkedList = new SLL();
            user1 = new User(1, "Kyle Guenter", "kyle@email.com", "password");
            user2 = new User(2, "Liv Cote", "liv@email.com", "password");
            user3 = new User(3, "Michael Makkerenko", "michael@email.com", "password");
        }

        [Test]
        public void TestEmptyLinkedList()
        {
            Assert.IsTrue(linkedList.IsEmpty());
            Assert.AreEqual(0, linkedList.Count());
        }

        [Test]
        public void TestPrepend()
        {
            linkedList.AddFirst(user1);

            Assert.IsFalse(linkedList.IsEmpty());
            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestAppend()
        {
            linkedList.AddLast(user1);

            Assert.IsFalse(linkedList.IsEmpty());
            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestInsertAtIndex()
        {
            linkedList.AddFirst(user1);
            linkedList.Add(user2, 1);

            Assert.AreEqual(2, linkedList.Count());
            Assert.AreEqual(user2, linkedList.GetValue(1));
        }

        [Test]
        public void TestReplace()
        {
            linkedList.AddFirst(user1);
            linkedList.Replace(user2, 0);

            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user2, linkedList.GetValue(0));
        }

        [Test]
        public void TestDeleteFromBeginning()
        {
            linkedList.AddFirst(user1);
            linkedList.AddLast(user2);

            linkedList.RemoveFirst();

            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user2, linkedList.GetValue(0));
        }

        [Test]
        public void TestDeleteFromEnd()
        {
            linkedList.AddFirst(user1);
            linkedList.AddLast(user2);

            linkedList.RemoveLast();

            Assert.AreEqual(1, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestDeleteFromMiddle()
        {
            linkedList.AddFirst(user1);
            linkedList.AddLast(user2);
            linkedList.AddLast(user3);

            linkedList.Remove(1);

            Assert.AreEqual(2, linkedList.Count());
            Assert.AreEqual(user1, linkedList.GetValue(0));
            Assert.AreEqual(user3, linkedList.GetValue(1));
        }

        [Test]
        public void TestFindAndRetrieve()
        {
            linkedList.AddFirst(user1);

            Assert.IsTrue(linkedList.Contains(user1));
            Assert.AreEqual(0, linkedList.IndexOf(user1));
        }

        // New Test Methods
        [Test]
        public void TestEmptyLinkedListAfterClear()
        {
            linkedList.AddFirst(user1);
            linkedList.Clear();

            Assert.IsTrue(linkedList.IsEmpty());
            Assert.AreEqual(0, linkedList.Count());
        }

        [Test]
        public void TestInsertAtIndexOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.Add(user1, 5));
        }

        [Test]
        public void TestDeleteFromEmptyList()
        {
            Assert.Throws<InvalidOperationException>(() => linkedList.RemoveFirst());
        }
    }
}