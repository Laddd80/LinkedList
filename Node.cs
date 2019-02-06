using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListNormnal
{
    //The item needs the node itself, and it needs to know if there is a next item followingit.
    class Node<T>
    {
        T node;
        Node<T> next;

        public T ListNode
        {
            get
            {
                return node;
            }

            set
            {
                node = value;
            }
        }
        internal Node<T> Next
        {
            get
            {
                return next;
            }

            set
            {
                next = value;
            }
        }

        public Node(T node)
        {
            ListNode = node;
        }
    }
}
