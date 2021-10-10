using System;


namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private LinkedListItem first;
        private LinkedListItem last;

        public int Count
        {
            get
            {
                int count = 0;

                LinkedListItem current = first;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }

                return count;
            }
        }

        public void AddFirst(int element)
        {
            LinkedListItem newItem = new LinkedListItem(element);

            if (first == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                newItem.Next = first;
                first.Previous = newItem;
                first = newItem;
            }
        }

        public void AddLast(int element)
        {
            LinkedListItem newItem = new LinkedListItem(element);
            if (last == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                last.Next = newItem;
                newItem.Previous = last;
                last = newItem;
            }
        }

        public int RemoveFirst()
        {
            if (first == null)
            {
                throw new InvalidOperationException("Linked List empty!");
            }

            int currentFirstValue = first.Value;
            if (first == last)
            {
                first = null;
                last = null;
            }
            else
            {
                LinkedListItem newFirst = first.Next;
                newFirst.Previous = null;
                first = newFirst;
            }

            return currentFirstValue;
        }

        public int RemoveLast()
        {
            if (last == null)
            {
                return 0;
            }

            int currentLastValue = last.Value;
            if (first == last)
            {
                first = null;
                last = null;

            }
            else
            {
                LinkedListItem newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
            }

            return currentLastValue;
        }

        public void ForEach(Action<int> action)
        {
            LinkedListItem current = first;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];

            LinkedListItem current = first;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Value;
                index++;
                current = current.Next;
            }

            return array;
        }
    }
}
