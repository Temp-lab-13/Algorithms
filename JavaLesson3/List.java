package JavaLesson3;

public class List {
    Node head;
    Node tail;

    // Добавление элемента в конец списка.
    public void addEnd(int value) {
        Node node = new Node(); // создаём новый узал.
        node.value = value; // ложим в него значение, которое хотим записать.
        if (head == null) // проверяем, что у нас в списке есть хоть что-то.
        { // если списко пуст, и голова null, то наше значение присваивается и в голлову и
          // в хвост.
            head = node;
            tail = node;
        } else // в противном случаи, вставляем прикрепляем новый узел к хвосту.
        {
            tail.next = node; // создаём связь от хвоста к новому узлу(он становиться хвостом).
            node.previos = tail; // связываем наш новый хвост с предыдущим хвостом.
            tail = node; // ложим в новый хвост наше новое значение.
        }
    }

    // Добавляем новый узел в любое место в списке.
    public void add(int value, Node node) // получаем значение, и ноду ПОСЛЕ которой вставляем новую.
    {
        Node next = node.next; //
        Node newNode = new Node(); // создаем новую ноду.
        newNode.value = value; // присваевыем ей полученное значение.
        node.next = newNode; // Указываем, что наша новая нода, это следующая нода от текущей.
        newNode.previos = node; // Указываем, что предыдущая нода от нашей новой ноды, это старая нода.
        if (next == null) // проверям, что бы наша новая нода не оказалась за пределами списка.
        {
            tail = newNode; // если она дальше текущего хвоста, то она становиться новым хвостом.
        } else {
            next.previos = newNode; // Указатель отташей ноды к следующей.
            newNode.next = next; // Указыватель для следующей ноды на нашу ноду.
        }
    }

    public void delet(Node node) {
        Node previous = node.previos;
        Node next = node.next;
        if (previous == null) // Если перед удаляемым узлом ничего нет(т.у он голова)
        {
            // Том мы удаляем связь от этой ноды.
            next.previos = null;
            // и объявляем слудующий узел головой.
            head = next;
        } else {
            if (next == null) // если после удалёмого узла ничего нет,
            {
                // то значит мы удаляем хвост,
                // удаляем связь псоледнего элемента с предыдущим,
                previous.next = null;
                // и говорим что предшествующий элемент новый хвост.
                tail = previous;
            } else {
                // Если же удаляемый узел не хвост или голова, то
                previous.next = next; // мы перекидываем от предыдущего узла связь к следующему.
                next.previos = previous; // а от следующего к предыдущему.
                // тем самым уюарая связи от удаляемого узла.
            }
        }
    }

    // Правильная реализация поиска элеме6нта в связном списке.
    public Node find(int value) {
        Node currentNode = head; // создаём временную переменную, в которую ложим гловной элемент.
        while (currentNode != null) // проверям что теекущий элемент вообще есть.
        {
            if (currentNode.value == value) // проверяем, значение элемента.
            {
                return currentNode; // если соотвествует запрашиваему, возращаем.
            }
            currentNode = currentNode.next; // если нет, то перемещаемся к следующему элементу по ссылке.
        }
        return null; // если искомого элемента в списке нет, то возращаем ничего.
    }

    // Разворот двусвязного списка.
    public void revert() {
        Node currentNode = head; // начинаем с головы.
        // проверяем что список не пуст, и заодно заставляем цикл пройтись по нему
        // всему.
        while (currentNode != null) {
            Node next = currentNode.next;
            Node previous = currentNode.previos;
            currentNode.next = previous; // меняем укаатели местами
            currentNode.previos = next;
            if (previous == null) { // предшествующий текущему узел null,
                tail = currentNode; // то значит мы в голове, и переназначаем её в хвост.
            }
            if (head == null) { // аналогично, но с хвостом.
                head = currentNode;
            }
            currentNode = next; // смещаемся дальше по списку.
        }
    }

    // Разворот для односвязного списка.
    // Головной модуль.
    public void revertOneList() {
        // проверяет что список не пуст, а так же имеет более одного узла.
        if (head != null && head.next != null) {
            Node temp = head;
            revertOneList(head.next, head); // если да, то запускаем.
            temp.next = null;
        }
    }

    // рабочий модуль разворота односвязного списка.
    // получаем следующий и текущий узел для оработки.
    private void revertOneList(Node currentNode, Node previousNode) {
        // если следующий узел отсутвует, то мы в хвосте,
        // переназначаем его в качестве головы.
        if (currentNode.next == null) {
            head = currentNode;
            // во всех остальных случаях, запускаем рекурсию.
        } else {
            revertOneList(currentNode.next, previousNode);
        }
        // смещаемся.
        currentNode.next = previousNode;
    }

    public class Node {
        int value;
        Node next;
        Node previos;
    }
}
