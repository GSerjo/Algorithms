import java.util.LinkedList;
import java.util.Queue;

public class tree_level_order_traversal {

    public static void main(String[] args) {

        Node root = new Node(){{data = 1;}};
        root.right = new Node(){{data = 2;}};
        root.right.right = new Node(){{data = 5;}};
        root.right.right.left = new Node(){{data = 3;}};
        root.right.right.right = new Node(){{data = 4;}};
        root.right.right.right = new Node(){{data = 6;}};

        levelOrder(root);
    }

    private static void levelOrder(Node root) {
        if (root == null) {
            return;
        }
        System.out.printf("%d ", root.data);

        Queue<Node> queue = new LinkedList<>();
        queue.add(root.left);
        queue.add(root.right);

        while (queue.isEmpty() == false) {
            Node node1 = queue.poll();

            if (node1 != null) {
                System.out.printf("%d ", node1.data);
                queue.add(node1.left);
                queue.add(node1.right);
            }
        }

//        System.out.print(String.join(" ", result.stream().map(Object:: toString).collect(Collectors.toList())));
    }

}
