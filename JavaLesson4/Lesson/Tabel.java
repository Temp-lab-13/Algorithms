package JavaLesson4.Lesson;

import java.util.ArrayList;
import java.util.List;

public class Tabel {
    Node root;

    // Проверка существования в дереве нужного узла с искомым значением.
    // зачем?
    public boolean exist(int value) {
        if (root != null) {
            Node node = find(root, value);
            if (node != null) {
                return true;
            }
        }
        return false;
    }

    // Обход в глубину.
    // Поиск конкретного значения в дереве.
    private Node find(Node node, int value) {
        if (node.value == value) { // если нашли
            return node; // то возращаем.
        } else { // нет
            for (Node child : node.children) { // присваивает child узел-ребёнка текущего узла
                Node result = find(child, value); // и запускаем рекурсию поиска со следующим узлом.
                if (result != null) { // если вернулось корректное значение, то
                    return result; // возращаем найденное.
                }
            }
        }
        return null; // если ничего не нашли, то возращаем null.
    }

    // Обход в ширину.
    // Поиск конкретного значения в дереве.
    private Node findNode(int value) {
        List<Node> line = new ArrayList<>();
        line.add(root);
        while (line.size() > 0) {
            List<Node> nextLine = new ArrayList<>();
            for (Node node : line) {
                if (node.value == value) {
                    return node;
                }
                nextLine.addAll(node.children);
            }
            line = nextLine;
        }
        return null;
    }

    public class Node {
        int value;
        List<Node> children;
    }
}
