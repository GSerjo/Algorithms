import edu.princeton.cs.algs4.Point2D;
import edu.princeton.cs.algs4.Queue;
import edu.princeton.cs.algs4.RectHV;

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
        root = insert2(root, point);
        size++;
    }

    public boolean contains(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }
        return contains2(root, point);
    }

    public Iterable<Point2D> range(RectHV rect) {
        if (rect == null) {
            throw new NullPointerException();
        }
        Queue<Point2D> result = new Queue<>();

        if (isEmpty()) {
            return result;
        }
        Queue<Node> nodes = new Queue<>();
        nodes.enqueue(root);

        while (!nodes.isEmpty()) {
            Node node = nodes.dequeue();
            if (node == null) {
                continue;
            }
            if (rect.contains(node.value)) {
                result.enqueue(node.value);
            }
            if (node.x) {
                if (node.value.x() > rect.xmax()) {
                    nodes.enqueue(node.left);
                } else if (node.value.x() < rect.xmin()) {
                    nodes.enqueue(node.right);
                } else {
                    nodes.enqueue(node.left);
                    nodes.enqueue(node.right);
                }
            } else {
                if (node.value.y() > rect.ymax()) {
                    nodes.enqueue(node.left);
                } else if (node.value.y() < rect.ymin()) {
                    nodes.enqueue(node.right);
                } else {
                    nodes.enqueue(node.left);
                    nodes.enqueue(node.right);
                }
            }
        }

        return result;
    }

    public Point2D nearest(Point2D point) {
        if (point == null) {
            throw new NullPointerException();
        }
        if (isEmpty()) {
            return null;
        }
        return nearest(root, point, root.value, new double[]{Double.MAX_VALUE});
    }

    private Point2D nearest(Node node, Point2D point, Point2D result, double[] distance) {
        if (node == null) {
            return result;
        }
        double currentDistance = point.distanceSquaredTo(node.value);
        if (currentDistance < distance[0]) {
            distance[0] = currentDistance;
            result = node.value;
        }
        if (node.rect.distanceSquaredTo(point) < distance[0]) {
            if (node.x) {
                if (point.x() < node.value.x()) {
                    nearest(node.left, point, result, distance);
                    nearest(node.right, point, result, distance);
                } else {
                    nearest(node.right, point, result, distance);
                    nearest(node.left, point, result, distance);
                }
            } else {
                if (point.y() < node.value.y()) {
                    nearest(node.left, point, result, distance);
                    nearest(node.right, point, result, distance);
                } else {
                    nearest(node.right, point, result, distance);
                    nearest(node.left, point, result, distance);
                }
            }
        }

        return result;
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

    private boolean contains2(Node root, Point2D point) {
        if (root == null) {
            return false;
        }
        int level = 0;
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

    private Node insert2(Node root, Point2D point) {
        double xmin = 0;
        double ymin = 0;
        double xmax = 1;
        double ymax = 1;
        int level = 0;
        if (root == null) {
            return new Node(point, new RectHV(xmin, ymin, xmax, ymax), true);
        }
        Node current = root;
        Node previous = null;
        boolean right = false;
        while (true) {
            if (current == null) {
                if (right) {
                    previous.right = new Node(point, new RectHV(xmin, ymin, xmax, ymax), isX(level));
                } else {
                    previous.left = new Node(point, new RectHV(xmin, ymin, xmax, ymax), isX(level));
                }
                break;
            }
            if (point.equals(current.value)) {
                break;
            }
            previous = current;
            if (isX(level)) {
                right = point.x() > current.value.x();
                if (right) {
                    xmin = current.value.x();
                } else {
                    xmax = current.value.x();
                }
                current = right ? current.right : current.left;
            } else {
                if (right) {
                    ymin = current.value.y();
                } else {
                    ymax = current.value.y();
                }
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
        private boolean x;
        private RectHV rect;


        public Node(Point2D point, RectHV rect, boolean x) {
            value = point;
            this.x = x;
            this.rect = rect;
        }

    }

}
