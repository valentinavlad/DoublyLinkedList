using System;
using Xunit;

namespace DoublyLinkList
{
    public class DoublyLinkListTests
    {

        [Fact]
        public void NodeIsNullShouldThrowException()
        {
            var dll = new DoublyLinkList<int>();
            Node<int> n = null;
            var ex = Assert.Throws<ArgumentNullException>(() => dll.AddBefore(n, 6));
            Assert.Equal("Value cannot be null. (Parameter 'node')", ex.Message);
        }

        [Fact]
        public void AddLastAndBefore()
        {
            var dll = new DoublyLinkList<int>();
      
            Node<int> node = new Node<int>(15);
            var newNode = new Node<int>(8);
            dll.AddLast(52);
            dll.AddLast(3);
            dll.AddLast(node);
            dll.AddBefore(node, newNode);
            int count = dll.Count;
            Assert.Equal(4, count);
        }

        [Fact]
        public void AddFirst()
        {
            var dll = new DoublyLinkList<int>();

            Node<int> node = new Node<int>(15);
            var newNode = new Node<int>(8);
            dll.AddLast(node); 
            
            dll.AddBefore(node, newNode);
            dll.AddBefore(newNode, 9);
            dll.AddLast(11);
            dll.AddFirst(100);
            int count = dll.Count;
            Assert.Equal(5, count);
        }

        [Fact]
        public void AddAfter()
        {
            var dll = new DoublyLinkList<int>();

            Node<int> node = new Node<int>(100);
            var newNode = new Node<int>(8);
            dll.AddFirst(node);
            dll.AddLast(56);
            dll.AddAfter(node, newNode);
            int count = dll.Count;
            Assert.Equal(3, count);
        }

        [Fact]
        public void Remove()
        {
            var dll = new DoublyLinkList<int>();

            Node<int> node = new Node<int>(100);
            var newNode = new Node<int>(8);
            var newNode2 = new Node<int>(82);
            dll.AddFirst(node);
            dll.AddLast(56);
            dll.AddAfter(node, newNode);
            dll.AddAfter(newNode, newNode2);
            dll.Remove(newNode);
            int count = dll.Count;
            Assert.Equal(3, count);
        }

        [Fact]
        public void RemoveBool()
        {
            var dll = new DoublyLinkList<int>();

            Node<int> node = new Node<int>(100);
            var newNode = new Node<int>(8);
            var newNode2 = new Node<int>(82);
            dll.AddFirst(node);
            dll.AddLast(56);
            dll.AddAfter(node, newNode);
            dll.AddAfter(newNode, newNode2);
            bool remove = dll.Remove(100);
            bool removeFalse = dll.Remove(589);
            int count = dll.Count;
            Assert.True(remove);
            Assert.False(removeFalse);
        }

        [Fact]
        public void RemoveFirst()
        {
            var dll = new DoublyLinkList<int>();
            // 100 150 56
            Node<int> node = new Node<int>(100);

            dll.AddFirst(node);
            dll.AddAfter(node, 150);
            dll.AddLast(56);
            dll.RemoveFirst();
            Assert.Equal(2, dll.Count);
        }

        [Fact]
        public void RemoveFirstThrowError()
        {
            var dll = new DoublyLinkList<int>();
            var ex = Assert.Throws<InvalidOperationException>(() => dll.RemoveFirst());
            Assert.Equal("There are no elements to be removed!", ex.Message);
        }

        [Fact]
        public void FindANode()
        {
            var dll = new DoublyLinkList<int>();
            //100  8 56
            Node<int> node = new Node<int>(100);
            var newNode = new Node<int>(8);
          

            dll.AddFirst(node);
            dll.AddLast(56);
            dll.AddAfter(node, newNode);
            var find = dll.Find(8);
            var find2 = dll.Find(68);

            int count = dll.Count;
            Assert.Equal(3, count);
            Assert.Equal(newNode, find);
            Assert.Null(find2);
        }

        [Fact]
        public void FindLastNode()
        {
            var dll = new DoublyLinkList<int>();
            //100  8 56
            Node<int> node = new Node<int>(100);
            Node<int> lastnode = new Node<int>(56);
            var newNode = new Node<int>(8);


            dll.AddFirst(node);
            dll.AddLast(lastnode);
            dll.AddAfter(node, newNode);
            var find = dll.FindLast(56);
            var findIsNull = dll.FindLast(100);

            Assert.Equal(lastnode, find);
            Assert.Null(findIsNull);
        }

        [Fact]
        public void CopyTo()
        {
            var dll = new DoublyLinkList<int>();
            // 100 150 56
            Node<int> node = new Node<int>(100);

            dll.AddFirst(node);
            dll.AddAfter(node, 150);
            dll.AddLast(56);

            int[] arr = new int[4];
            dll.CopyTo(arr, 0);
            Assert.Equal(100, arr[0]);
            Assert.Equal(56, arr[2]);
        }
    }
}
