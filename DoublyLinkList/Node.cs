using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkList
{
    public class Node<T>
    {
        private T data;
        private Node<T> next;
        private Node<T> prev;

        public Node(T data) => Data = data;
        
        public Node()
        {
            
        }
        public T Data
        {
            get => data;
            set => data = value;
        }

        public Node<T> Next
        {
            get => next;
            set => next = value;
        }

        public Node<T> Prev 
        {
            get => prev;
            set => prev = value;
        }
    }
}
