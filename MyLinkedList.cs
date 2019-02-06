using LinkedListNormnal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListNormal
{
    class MyLinkedList<T> : IEnumerable<T>
    {
        Node<T> first;

        //Insertion at the end
        public void Insert(T node)
        {
            Node<T> newNode = new Node<T>(node);

            if (first == null)
            {
                first = newNode; //If there are no elements in the list, then the new element will be the first one
            }
            else
            {
                //If we have item in the first element, then we move through the items until the Next element is empty
                Node<T> current = first;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode; //If the Next is empty, then we can insert our new element at the end
            }
        }

        //Insert to specified index
        public void Insert(T node, int index)
        {
            Node<T> newNode = new Node<T>(node);

            //If the first node is empty, and we have the index 0, then we can insert it as the first
            if (first == null && index == 0)
            {
                first = newNode;
            }
            else
            {
                Node<T> current = first;
                Node<T> prev = null; //We have to track the previous nodes aswell, becouse we will insert the new one most probably between two existing ones
                int i = 0; //To track the index of the checked elements
                while (current != null && index != i)
                {
                    prev = current;
                    current = current.Next;
                    i++;
                }
                if (prev == null)
                {
                    /*If there is a first element, but we want to insert the new element to index 0, then the new element will be the new first one, and it's
                     * Next element will be the "first" element*/
                    newNode.Next = first;
                    first = newNode;
                }
                else if (index == i)
                {
                    /*If the previous is not empty, then we have to change the prev.Next item to the new element
                     * and the current element will be the Next element of our inserted Node*/
                    prev.Next = newNode;
                    if (current != null)
                    {
                        newNode.Next = current;
                    }
                }
                else
                {
                    throw new ArgumentException("No item can be created for the given index");
                }
            }
        }
        //Delete element
        public void Delete(T toDelete)
        {
            if (first != null)
            {
                Node<T> current = first;
                Node<T> prev = null;
                //Move on to the next element until it equals with the element we want to delete
                while (current != null && !current.ListNode.Equals(toDelete))
                {
                    prev = current;
                    current = current.Next;
                }

                if (first == null)
                {
                    first = first.Next; //References need to be kept
                }
                else if (current != null)
                {
                    if (prev != null)
                    {
                        //Simply set the Next element of the previous Node to the Next element of the current node, and with that our current Node was eliminated
                        prev.Next = current.Next;
                    }
                    else
                    {
                        //If it is the first node we want to delete, then we have to set the current.Next as first
                        first = current.Next;
                    }

                }
            }
        }

        //Search throuht the linked list
        public bool Search(T searchedItem)
        {
            Node<T> current = first;
            while (current != null && !current.ListNode.Equals(searchedItem))
            {
                current = current.Next;
            }
            return current != null;
        }


        //To support iteration
        public IEnumerator<T> GetEnumerator()
        {
            return new WalkthroughLinkedList<T>(first);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new WalkthroughLinkedList<T>(first);
        }
    }

    internal class WalkthroughLinkedList<T> : IEnumerator<T>
    {
        private Node<T> first;
        Node<T> current;

        public WalkthroughLinkedList(Node<T> first)
        {
            this.first = first;
            current = null;
        }

        public T Current
        {
            get
            {
                return current.ListNode;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return current.ListNode;
            }
        }

        public void Dispose()
        {
            first = null;
            current = null;
        }

        public bool MoveNext()
        {
            if (first != null)
            {
                if (current == null)
                {
                    current = first;
                    return true;
                }
                else if (current.Next != null)
                {
                    current = current.Next;
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            current = null;
        }
    }
}
