//    Реализация двусвязного списка списка.

using System.Text;

public class TwoLinkedList
{
    private Node head;
    private Node tail;
    //Добавление новго первого элемента.
    public void addFirst(int value)
    {
        Node node = new Node(value);
        if (head != null)
        {
            node.next = head;
            head.previous = node;
        }
        else
        {
            tail = node;
        }
        head = node;
    }
    //Удаление элемента.
    public void deletFirst()
    {
        if (head != null && head.previous != null)
        {
            head.next.previous = null;
            head = head.next;
        }
        else
        {
            head = null;
            tail = null;
        }
    }

    // Добавление в конец списка.
    public void addLast(int value)
    {
        Node node = new Node(value);
        if (tail == null)
        { //список пуст
            tail = node;
        }
        else //список наполнен
        {
            Node current = tail;
            tail.next = node;
            node.previous = current;
        }
        tail = node;
    }
    // Удаление последнего элемента списка.
    public void removeLast()
    {
        if (tail != null && tail.previous != null)
        {
            tail.next.previous = null;
            tail = tail.next;
        }
        else
        {
            head = null;
            tail = null;
        }
    }

    //Метод вывода.
    public void print()
    {
        Node node = head;
        while (node != null)
        {
            Console.Write(node.value);
            node = node.next;
        }
    }
    //сортировка пузырьком.
    public void sort()
    {
        bool flag;
        do
        {
            flag = false;
            Node node = head;
            while (node != null && node.next != null)
            {
                if (node.value > node.next.value)
                {
                    Node bofore = node.previous;
                    Node after = node.next.next;
                    Node current = node;
                    Node next = node.next;

                    current.next = after;
                    current.previous = next;
                    next.next = current;
                    next.previous = bofore;

                    if (bofore != null)
                    {
                        bofore.next = next;
                    }
                    else
                    {
                        head = next;

                    }
                    if (after != null)
                    {
                        after.previous = current;
                    }
                    else
                    {
                        tail = current;
                    }
                    flag = true;
                }
                node = node.next;
            }
        } while (flag);
    }


    public class Node
    {
        public int value;
        public Node next;
        public Node previous;


        public Node(int value)
        {
            this.value = value;
            this.next = null;
            this.previous = null;
        }

    }
    //Поиск элемента в списке.
    public Node find(int target)
    {
        while (head != null)
        {
            if (head.value == target)
            {
                return head;
            }
            head = head.next;
        }
        return null;
    }
    //Проверяет, есть ли искомый элемент в списке.
    public bool isContains(int target)
    {
        return find(target) != null ? true : false;
    }
}