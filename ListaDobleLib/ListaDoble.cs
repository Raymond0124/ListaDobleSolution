using System;

public enum SortDirection
{
    Asc,
    Desc
}

public class DoublyLinkedListNode
{
    public int Value { get; set; }
    public DoublyLinkedListNode Next { get; set; }
    public DoublyLinkedListNode Prev { get; set; }

    public DoublyLinkedListNode(int value)
    {
        Value = value;
        Next = null;
        Prev = null;
    }
}

public interface IList
{
    void InsertInOrder(int value);
    int DeleteFirst();
    int DeleteLast();
    bool DeleteValue(int value);
    int GetMiddle();
    void MergeSorted(IList listA, IList listB, SortDirection direction);
    void InvertList();
}

public class DoublyLinkedList : IList
{
    private DoublyLinkedListNode head;
    private DoublyLinkedListNode tail;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
    }

    public void InsertInOrder(int value)
    {
        var newNode = new DoublyLinkedListNode(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
            return;
        }

        if (value < head.Value)
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
            return;
        }

        var current = head;
        while (current.Next != null && current.Next.Value < value)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            current.Next = newNode;
            newNode.Prev = current;
            tail = newNode;
        }
        else
        {
            newNode.Next = current.Next;
            current.Next.Prev = newNode;
            newNode.Prev = current;
            current.Next = newNode;
        }
    }

    public int DeleteFirst()
    {
        if (head == null) throw new InvalidOperationException("List is empty");

        var value = head.Value;
        head = head.Next;
        if (head != null) head.Prev = null;
        else tail = null;

        return value;
    }

    public int DeleteLast()
    {
        if (tail == null) throw new InvalidOperationException("List is empty");

        var value = tail.Value;
        tail = tail.Prev;
        if (tail != null) tail.Next = null;
        else head = null;

        return value;
    }

    public bool DeleteValue(int value)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value == value)
            {
                if (current.Prev != null) current.Prev.Next = current.Next;
                else head = current.Next;

                if (current.Next != null) current.Next.Prev = current.Prev;
                else tail = current.Prev;

                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public int GetMiddle()
    {
        if (head == null) throw new InvalidOperationException("List is empty");

        var slow = head;
        var fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow.Value;
    }

    public void MergeSorted(IList listA, IList listB, SortDirection direction)
    {
        var a = (DoublyLinkedList)listA;
        var b = (DoublyLinkedList)listB;

        if (a.head == null && b.head == null)
        {
            throw new InvalidOperationException("Both lists are null");
        }

        var result = new DoublyLinkedList();
        var currentA = a.head;
        var currentB = b.head;

        if (direction == SortDirection.Asc)
        {
            while (currentA != null && currentB != null)
            {
                if (currentA.Value < currentB.Value)
                {
                    result.InsertInOrder(currentA.Value);
                    currentA = currentA.Next;
                }
                else
                {
                    result.InsertInOrder(currentB.Value);
                    currentB = currentB.Next;
                }
            }
        }
        else
        {
            while (currentA != null && currentB != null)
            {
                if (currentA.Value > currentB.Value)
                {
                    result.InsertInOrder(currentA.Value);
                    currentA = currentA.Next;
                }
                else
                {
                    result.InsertInOrder(currentB.Value);
                    currentB = currentB.Next;
                }
            }
        }

        while (currentA != null)
        {
            result.InsertInOrder(currentA.Value);
            currentA = currentA.Next;
        }

        while (currentB != null)
        {
            result.InsertInOrder(currentB.Value);
            currentB = currentB.Next;
        }

        a.head = result.head;
        a.tail = result.tail;
    }

    public void InvertList()
    {
        if (head == null) return;

        var current = head;
        DoublyLinkedListNode temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }

        if (temp != null)
        {
            head = temp.Prev;
        }
    }
}
