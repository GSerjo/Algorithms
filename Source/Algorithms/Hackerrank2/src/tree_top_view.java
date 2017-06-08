
public class tree_top_view {

    public static void main(String[] args){
        Node root = new Node(){{data = 1;}};
        root.right = new Node(){{data = 2;}};
        root.right.right = new Node(){{data = 5;}};
        root.right.right.left = new Node(){{data = 3;}};
        root.right.right.right = new Node(){{data = 4;}};
        root.right.right.right = new Node(){{data = 6;}};

        topView(root);
    }


    private static void topView(Node root){
        if(root == null){
            return;
        }
        topView(root.left, true);
        System.out.printf("%d", root.data);
        topView(root.right, false);
    }

    private static void topView(Node node, boolean left){
        if(node == null){
            return;
        }

        if(left){
            topView(node.left, true);
            System.out.printf("%d ", node.data);
        }
        else{
            System.out.printf(" %d", node.data);
            topView(node.right,  false);
        }
    }
}


