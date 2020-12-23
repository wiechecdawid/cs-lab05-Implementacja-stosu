using System;
using System.Collections.Generic;
using System.Text;

namespace Stos
{
    public class CustomLinkedList<T>
    {
        private class Node
        {
            private T _node;
            
            public Node(T node)
            {
                _node = node;
            }

            public T Next { get; set; }
        }
    }
}
