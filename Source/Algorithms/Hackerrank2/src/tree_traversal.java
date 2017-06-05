/**
 * Created by Serjo on 05/06/2017.
 */
public class tree_traversal {


    public static void main(String[] args) {
        Node root = new Node(){{data = 1;}};
        root.right = new Node(){{data = 2;}};
        root.right.right = new Node(){{data = 5;}};
        root.right.right.left = new Node(){{data = 3;}};
        root.right.right.right = new Node(){{data = 6;}};

        preOrder(root);
        System.out.println();
        postOrder(root);
        System.out.println();
        inOrder(root);
    }


    private static void preOrder(Node root) {
        if(root == null){
            return;
        }
        System.out.printf("%d ", root.data);
        preOrder(root.left);
        preOrder(root.right);
    }

    static void postOrder(Node root) {
        if(root == null){
            return;
        }

        postOrder(root.left);
        postOrder(root.right);
        System.out.printf("%d ", root.data);
    }

    static void inOrder(Node root) {
        if(root == null){
            return;
        }

        inOrder(root.left);
        System.out.printf("%d ", root.data);
        inOrder(root.right);
    }
}


class Node {
    int data;
    Node left;
    Node right;
}