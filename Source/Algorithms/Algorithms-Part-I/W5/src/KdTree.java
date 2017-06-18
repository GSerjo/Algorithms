import edu.princeton.cs.algs4.Point2D;

public class KdTree {

    private Node root;
    private int size;

    public boolean isEmpty() {
        return size == 0;
    }

    public void insert(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }
        root = insert2(root, point, 0);
        size++;
    }

    public boolean contains(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }
        return contains2(root, point, 0);
    }


//    private boolean contains(Node root, Point2D point, int level) {
//        if (root == null) {
//            return false;
//        }
//        if (point.equals(root.value)) {
//            return true;
//        }
//        if (isX(level)) {
//            if (point.x() > root.value.x()) {
//                return contains(root.right, point, level + 1);
//            } else {
//                return contains(root.left, point, level + 1);
//            }
//        } else {
//            if (point.y() > root.value.y()) {
//                return contains(root.right, point, level + 1);
//            } else {
//                return contains(root.left, point, level + 1);
//            }
//        }
//    }

    private boolean contains2(Node root, Point2D point, int level) {
        if (root == null) {
            return false;
        }
        Node current = root;
        while (true) {
            if (current == null) {
                return false;
            }
            if (point.equals(current.value)) {
                return true;
            }
            if (isX(level)) {
                current = point.x() > current.value.x() ? current.right : current.left;
            } else {
                current = point.y() > current.value.y() ? current.right : current.left;
            }
            level++;
        }
    }

//    private Node insert(Node root, Point2D point, int level) {
//        if (isEmpty() || root == null) {
//            return new Node(point);
//        }
//        if (point.equals(root.value)) {
//            return root;
//        }
//        if (isX(level)) {
//            if (point.x() > root.value.x()) {
//                root.right = insert(root.right, point, level + 1);
//            } else {
//                root.left = insert(root.left, point, level + 1);
//            }
//        } else {
//            if (point.y() > root.value.y()) {
//                root.right = insert(root.right, point, level + 1);
//            } else {
//                root.left = insert(root.left, point, level + 1);
//            }
//        }
//        return root;
//    }

    private Node insert2(Node root, Point2D point, int level) {
        if (root == null) {
            return new Node(point);
        }
        Node current = root;
        Node previous = null;
        boolean right = false;
        while (true) {
            if (current == null && previous != null) {
                if (right) {
                    previous.right = new Node(point);
                } else {
                    previous.left = new Node(point);
                }
                break;
            }
            if (point.equals(current.value)) {
                break;
            }
            previous = current;
            if (isX(level)) {
                right = point.x() > current.value.x();
                current = right ? current.right : current.left;
            } else {
                right = point.y() > current.value.y();
                current = right ? current.right : current.left;
            }
            level++;
        }

        return root;
    }

    private boolean isX(int level) {
        return level % 2 == 0;
    }


    private class Node {
        private Node left;
        private Node right;
        private Point2D value;

        public Node(Point2D point) {
            value = point;
        }

    }

}
