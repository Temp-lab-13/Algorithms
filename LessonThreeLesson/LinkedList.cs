//Базовая реализация двусвязного списка.
public class LinkedList
{
    private Node head;
    private Node tail;

    //Поиск элемента в связном списке, методо перебора.
    public Node findNode(int value)
    {
        Node node = head;
        while (node.nextNode != null) //Что если список из одного узла?
        {
            if (node.value == value)
            {
                return node;
            }
            node = node.nextNode;//До или после if? Что если искомое в первом узле? 
        }
        return null;
    }
    //обавление элемента в любой участок списка.
    public void add(int value, Node previousNode)
    {
        Node node = new Node();
        node.value = value;
        Node nextNode = previousNode.nextNode;
        previousNode.nextNode = node;
        node.previousNode = previousNode;
        node.nextNode = nextNode;
        nextNode.previousNode = node;
    }

    //Добавление элемента в конец двусвязного списка.
    public void addLast(int value)
    {
        Node node = new Node();
        node.value = value;
        tail.nextNode = node;
        node.previousNode = tail;
        tail = node;
    }
    //Метод сортировки выбором. Голова. 
    //Эта часть перебирает список, 
    //и выискивает элементы что нужно пометь местами.
    public void sortSelection()
    {
        Node node = head;
        while (node.nextNode != null)
        {
            Node minPositionNode = node;
            Node innerNode = node.nextNode;
            while (innerNode != null)
            {
                if (innerNode < minPositionNode)
                {
                    minPositionNode = innerNode;
                }
                innerNode = innerNode.nextNode;
            }

            if (minPositionNode != node)
            {
                swap(node, minPositionNode);
                if (minPositionNode.previousNode == null)
                {
                    head = minPositionNode;
                }
                if (node.nextNode == null)
                {
                    tail = node;
                }

                node = minPositionNode.nextNode;
            }
            else
            {
                node = node.nextNode;
            }
        }
    }
    //Проолжение метода сортировки выбором.
    //Здесь происходит сдвиг найденных элементов.
    private void swap(Node node1, Node node2)
    {
        Node temp = node1.previousNode;
        node1.previousNode = node2.previousNode;
        node2.previousNode = temp;
        temp = node1.nextNode;
        node1.nextNode = node2.nextNode;
        node2.nextNode = temp;

        if (node2.previousNode != null)
        {
            node2.previousNode.nextNode = node2;
        }
        if (node2.nextNode != null)
        {
            node2.nextNode.previousNode = node2;
        }
        if (node1.previousNode != null)
        {
            node1.previousNode.nextNode = node1;
        }
        if (node1.nextNode != null)
        {
            node1.nextNode.previousNode = node1;
        }
    }
    //Разворот списка.
    public void revers()
    {
        Node node = head;

        Node tepm = head;
        head = tail;
        tail = tepm;

        while (node.nextNode != null)
        {
            tepm = node.nextNode;
            node.nextNode = node.previousNode;
            node.previousNode = tepm;
            node = node.previousNode;
        }
    }

    class Node
    {
        private int value;
        private Node nextNode;
        private Node previousNode;
    }
}