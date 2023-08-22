
//    Реализация простого односвязного списка.

using System.Text;

public class LinkedList
{
    private Node head;
    //Добавление новго первого элемента.
    public void addFirst(int value)
    {
        Node node = new Node();
        node.value = value;
        if (head != null)
        {
            node.next = head;
        }
        head = node;
    }
    //Удаление элемента.
    public void deletFirst()
    {
        if (head != null)
        {
            head = head.next;
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
    // Добавление в конец списка.
    public void addLast(int value)
    {
        Node node = new Node(value);
        if (head == null)
        { //список пуст
            head = node;
        }
        else //список наполнен
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = node;
        }
    }
    // Удаление последнего элемента списка.
    public void removeLast()
    {
        if (head != null)
        {
            Node current = head;
            while (current.next != null)
            {
                if (current.next.next == null)
                {
                    current.next = null;
                    return;
                }
                current = current.next;
            }
            head = null;
        }
    }

    //Рабочий метод вывода.
    public void print()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.value);
            current = current.next;
        }
    }


    public class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
            this.next = null;
        }
        public Node()
        {

        }
    }
}

