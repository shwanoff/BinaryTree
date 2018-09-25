using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shvanov.TreeCompare.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        [TestMethod()]
        public void BinaryTreeTest()
        {
            // Arrange.
            var middleInt = int.MaxValue / 2;
            var itemCount = 1000000;
            var binaryTree = new BinaryTree(middleInt);
            var items = new List<int>(itemCount * 2);
            var items2 = new List<int>(itemCount * 2);
            var binaryTreeSame = new BinaryTree(middleInt);
            var binaryTreeAnother = new BinaryTree(middleInt);
            var binaryTreeLessSame = new BinaryTree(middleInt);
            var binaryTreeMoreSame = new BinaryTree(middleInt);
            var rnd = new Random();

            for(var i = 0; i < itemCount; i++)
            {
                items.Add(rnd.Next());
                items2.Add(rnd.Next());
            }

            // Act.
            foreach(var item in items)
            {
                binaryTree.Add(item);
                binaryTreeSame.Add(item);
                binaryTreeMoreSame.Add(item);
            }

            foreach(var item in items.Take(items.Count / 2))
            {
                binaryTreeLessSame.Add(item);
            }

            foreach(var item in items2)
            {
                binaryTreeAnother.Add(item);
                binaryTreeMoreSame.Add(item);
            }

            // Assert.
            Assert.IsTrue(binaryTree.Equals(binaryTree));
            Assert.IsTrue(binaryTree.Equals(binaryTreeSame));
            Assert.IsFalse(binaryTree.Equals(binaryTreeAnother));
            Assert.IsFalse(binaryTree.Equals(binaryTreeLessSame));
            Assert.IsFalse(binaryTree.Equals(binaryTreeMoreSame));
        }
    }
}